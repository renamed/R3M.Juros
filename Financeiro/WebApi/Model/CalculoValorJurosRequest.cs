using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Model
{
    public class CalculoValorJurosRequest
    {
        public decimal ValorInicial { get; set; }
        public int QtdMeses { get; set; }
    }
}
