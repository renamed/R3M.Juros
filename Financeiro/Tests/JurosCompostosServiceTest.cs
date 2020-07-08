using Domain;
using ExternalServices;
using ExternalServices.Interfaces;
using NSubstitute;
using Services;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Tests
{
    public class JurosCompostosServiceTest
    {
        private const int QtdMesesValida = 10;
        private const decimal ValorInicialValido = 79.25M;
        
        private IFinanceiroService GetServicoFinanceiro(decimal? taxa = null)
        {
            var indicadorExternalService = Substitute.For<IIndicadoresExternalService>();
            if (taxa.HasValue)
                indicadorExternalService.GetTaxaJuros().Returns<Juros>(s => new Juros { Taxa = taxa.Value });
            
            return new FinanceiroService(indicadorExternalService);
        }

        [Theory]
        [InlineData(-5.43)]
        [InlineData(0)]
        public async Task DeveLancarExcecaoComValorInicialNegativoOuZerado(decimal valorInicial)
        {
            var financeiroService = GetServicoFinanceiro();
            var exception = await Assert.ThrowsAsync<ValidationException>(() => financeiroService.CalcularJurosCompostos(valorInicial, QtdMesesValida));
            Assert.Equal("O valor inicial precisa ser maior que zero", exception.Message);            
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        public async Task DeveLancarExcecaoComQtdMesesNegativoOuZerado(int qtdDias)
        {
            var financeiroService = GetServicoFinanceiro();

            var exception = await Assert.ThrowsAsync<ValidationException>(() => financeiroService.CalcularJurosCompostos(ValorInicialValido, qtdDias));
            Assert.Equal("A quantidade de meses precisa ser maior que zero", exception.Message);
        }

        [Theory]
        [InlineData(100, 5, 0.01, 105.1)]
        [InlineData(500, 7, 0.4868, 8030.41)]
        [InlineData(6.66, 3, 0.33, 15.66)]
        public async Task DeveCalcularJurosCompostosCorretamente(decimal valorInicial, int qtdMeses, decimal taxa, decimal valorFinal)
        {
            var financeiroService = GetServicoFinanceiro(taxa);
            var res = await financeiroService.CalcularJurosCompostos(valorInicial, qtdMeses);

            Assert.Equal(valorFinal, res, 2);
        }
    }
}
