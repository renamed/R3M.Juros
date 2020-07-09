using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xunit;

namespace IntegrationTests
{
    public class CalcularJurosCompostos
    {
        private const string JUROS_COMPOSTOS_URL = "http://localhost:8666/api/Financeiro/juros/compostos?ValorInicial={0}&QtdMeses={1}";
        private const int QTD_MESES_VALIDO = 5;
        private const decimal VALOR_INICIAL_VALIDO = 100M;
        
        [Fact]
        public async Task DeveRetornar400ComValorInicialZero()
        {
            string url = string.Format(JUROS_COMPOSTOS_URL, 0, QTD_MESES_VALIDO);
            using(var request = new HttpClient())
            {
                var response = await request.GetAsync(url);
                Assert.Equal(400, (int)response.StatusCode);
            }
        }   

        [Fact]
        public async Task DeveRetornar400ComValorInicialNegativo()
        {
            double valorInicial = new Random().NextDouble() * (-600 - (-1)) + (-1);
            string url = string.Format(JUROS_COMPOSTOS_URL, valorInicial, QTD_MESES_VALIDO);
            using(var request = new HttpClient())
            {
                var response = await request.GetAsync(url);
                Assert.Equal(400, (int)response.StatusCode);
            }
        }     

        [Fact]
        public async Task DeveRetornar400ComQtdMesesZero()
        {
            string url = string.Format(JUROS_COMPOSTOS_URL, VALOR_INICIAL_VALIDO, 0);
            using(var request = new HttpClient())
            {
                var response = await request.GetAsync(url);
                Assert.Equal(400, (int)response.StatusCode);
            }
        }  

        [Fact]
        public async Task DeveRetornar400ComQtdMesesNegativo()
        {
            int qtdMesesInvalido = new Random().Next(-10, -1);
            string url = string.Format(JUROS_COMPOSTOS_URL, VALOR_INICIAL_VALIDO, qtdMesesInvalido);
            using(var request = new HttpClient())
            {
                var response = await request.GetAsync(url);
                Assert.Equal(400, (int)response.StatusCode);
            }
        } 

        [Fact]
        public async Task DeveRetornar200ComParametrosValidos()
        {
            string url = string.Format(JUROS_COMPOSTOS_URL, VALOR_INICIAL_VALIDO, QTD_MESES_VALIDO);
            using(var request = new HttpClient())
            {
                var response = await request.GetAsync(url);
                Assert.Equal(200, (int)response.StatusCode);
            }
        }

        [Fact]
        public async Task DeveRetornarValorCalculadoComParametrosValidos()
        {
            string url = string.Format(JUROS_COMPOSTOS_URL, VALOR_INICIAL_VALIDO, QTD_MESES_VALIDO);
            using(var request = new HttpClient())
            {
                var response = await request.GetAsync(url);
                var objResponse = JsonConvert.DeserializeObject<JurosCompostosResponse>(await response.Content.ReadAsStringAsync());

                Console.WriteLine(objResponse);

                Assert.Equal(105.1M, objResponse.ValorFinal);
            }
        }
    }

    class JurosCompostosResponse
    {
        public decimal ValorFinal { get; set; }
    }
}