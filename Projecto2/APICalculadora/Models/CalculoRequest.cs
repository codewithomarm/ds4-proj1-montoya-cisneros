using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace APICalculadora.Models
{
    public class CalculoRequest
    {
        [Required(ErrorMessage = "La expresión es requerida")]
        public string Expresion { get; set; }

        [Required(ErrorMessage = "El resultado es requerido")]
        public string Resultado { get; set; }

        [Required(ErrorMessage = "El tipo es requerido")]
        [TipoCalculoValidation(ErrorMessage = "El tipo de cálculo no es válido")]
        public string Tipo { get; set; }
    }
}