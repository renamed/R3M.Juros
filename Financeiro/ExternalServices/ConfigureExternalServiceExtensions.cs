using Domain;
using ExternalServices.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExternalServices
{
    public static class ConfigureExternalServiceExtensions
    {
        public static void ConfigureExternalServicesExtensions(this IServiceCollection services)
        {
            services.AddTransient<IIndicadoresExternalService, IndicadoresExternalService>();            
        }
    }
}
