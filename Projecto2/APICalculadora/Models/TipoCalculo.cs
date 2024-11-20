using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APICalculadora.Models
{
    public enum TipoCalculo
    {
        suma,
        resta,
        multiplicacion,
        division,
        potencia,
        raiz,
        logaritmo,
        desconocido,
        mixto
    }
}