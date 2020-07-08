using Domain;
using ExternalServices.Interfaces;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ExternalServices
{
    public class IndicadoresExternalService : IIndicadoresExternalService
    {
        private readonly Config _config;

        public IndicadoresExternalService(IOptions<Config> config)
        {
            _config = config.Value;
        }

        public async Task<Juros> GetTaxaJuros()
        {
            var url = $"{_config.IndicadoresUrl}/{_config.GetTaxaJurosUrl}";
            using(var request = new HttpClient())
            {
                var response = await request.GetAsync(url);
                response.EnsureSuccessStatusCode();

                var jsonResponse = await response.Content.ReadAsStringAsync();
                
                return JsonConvert.DeserializeObject<Juros>(jsonResponse);
            }
        }
    }
}
