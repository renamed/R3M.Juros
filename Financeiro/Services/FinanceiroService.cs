using Domain;
using ExternalServices.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class FinanceiroService : IFinanceiroService
    {
        private readonly IIndicadoresExternalService _indicadoresExternalService;

        public FinanceiroService(IIndicadoresExternalService indicadoresExternalService)
        {
            _indicadoresExternalService = indicadoresExternalService;
        }

        public async Task<decimal> CalcularJurosCompostos(decimal valorInicial, int qtdMeses)
        {
            if (valorInicial <= 0)
                throw new ValidationException("O valor inicial precisa ser maior que zero");

            if (qtdMeses <= 0)
                throw new ValidationException("A quantidade de meses precisa ser maior que zero");

            var taxaDeJuros = await _indicadoresExternalService.GetTaxaJuros();

            return valorInicial * Convert.ToDecimal(Math.Pow(Convert.ToDouble(1 + taxaDeJuros.Taxa), qtdMeses));
        }
    }
}
