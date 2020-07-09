using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xunit;

namespace IntegrationTests
{
    public class GetRepositorioCodigo
    {
        private const string REPOSITORIO_CODIGO_URL = "http://localhost:8666/api/Metadata/code";

        [Fact]
        public async Task DeveRetornar200()
        {
            using(var request = new HttpClient())
            {
                var response = await request.GetAsync(REPOSITORIO_CODIGO_URL);
                Assert.Equal(200, (int)response.StatusCode);
            }
        }

        [Fact]
        public async Task DeveRetornarUmaUrl()
        {
            using(var request = new HttpClient())
            {
                var response = await request.GetAsync(REPOSITORIO_CODIGO_URL);
                var objResponse = JsonConvert.DeserializeObject<RepositorioCodigoResponse>(await response.Content.ReadAsStringAsync());

                Assert.True(Uri.IsWellFormedUriString(objResponse.Url, UriKind.Absolute));
                
            }
        }

        class RepositorioCodigoResponse
        {
            public string Url { get; set; }
        }
    }
}