using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Web;

namespace APICalculadora.Models
{
    public class Calculo
    {
        public int Id { get; set; }
        public string Expresion { get; set; }
        public string Resultado { get; set; }
        public string Tipo { get; set; }
        public DateTime Fecha { get; set; }
    }
}