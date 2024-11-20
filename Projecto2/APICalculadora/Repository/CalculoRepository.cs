using APICalculadora.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace APICalculadora.Repository
{
    public class CalculoRepository : ICalculoRepository
    {
        private string connectionString = "Server=LAPTOP-83KR8TDO\\SQLEXPRESS2;Database=calculadoradb;Trusted_Connection=True;TrustServerCertificate=True;";

        public List<Calculo> GetAllCalculos()
        {
            List<Calculo> calculos = new List<Calculo>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT Id, Expresion, Resultado, Tipo, Fecha FROM calculos";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            calculos.Add(new Calculo
                            {
                                Id = reader.GetInt32(0),
                                Expresion = reader.GetString(1),
                                Resultado = reader.GetString(2),
                                Tipo = reader.GetString(3),
                                Fecha = reader.GetDateTime(4)
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al obtener los cálculos: {ex.Message}");
                }
            }
            return calculos;
        }

        public List<Calculo> GetCalculosByTipo(string tipo)
        {
            List<Calculo> calculos = new List<Calculo>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT Id, Expresion, Resultado, Tipo, Fecha FROM calculos WHERE Tipo = @Tipo";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Tipo", tipo);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                calculos.Add(new Calculo
                                {
                                    Id = reader.GetInt32(0),
                                    Expresion = reader.GetString(1),
                                    Resultado = reader.GetString(2),
                                    Tipo = reader.GetString(3),
                                    Fecha = reader.GetDateTime(4)
                                });
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al obtener los cálculos por tipo: {ex.Message}");
                }
            }
            return calculos;
        }

        public Calculo AddCalculo(CalculoRequest request)
        {
            Calculo nuevoCalculo = null;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"INSERT INTO calculos (Expresion, Resultado, Tipo, Fecha) 
                                     VALUES (@Expresion, @Resultado, @Tipo, @Fecha); 
                                     SELECT CAST(SCOPE_IDENTITY() as int)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Expresion", request.Expresion);
                        cmd.Parameters.AddWithValue("@Resultado", request.Resultado);
                        cmd.Parameters.AddWithValue("@Tipo", request.Tipo);
                        cmd.Parameters.AddWithValue("@Fecha", DateTime.Now);

                        int newId = Convert.ToInt32(cmd.ExecuteScalar());
                        nuevoCalculo = new Calculo
                        {
                            Id = newId,
                            Expresion = request.Expresion,
                            Resultado = request.Resultado,
                            Tipo = request.Tipo,
                            Fecha = DateTime.Now
                        };
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al agregar el cálculo: {ex.Message}");
                }
            }
            return nuevoCalculo;
        }
    }
}