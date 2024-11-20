using APICalculadora.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APICalculadora.Repository
{
    public interface ICalculoRepository
    {
        List<Calculo> GetAllCalculos();
        List<Calculo> GetCalculosByTipo(string tipo);
        Calculo AddCalculo(CalculoRequest request);
    }
}
