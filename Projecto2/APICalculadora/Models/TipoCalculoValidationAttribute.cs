using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace APICalculadora.Models
{
    public class TipoCalculoValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return new ValidationResult("El tipo de cálculo no puede ser nulo");
            }

            if (Enum.TryParse(value.ToString(), true, out TipoCalculo tipoCalculo))
            {
                return ValidationResult.Success;
            }

            return new ValidationResult("El tipo de cálculo no es válido");
        }
    }
}