using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IFinanceiroService
    {
        Task<decimal> CalcularJurosCompostos(decimal valorInicial, int qtdMeses);
    }
}
