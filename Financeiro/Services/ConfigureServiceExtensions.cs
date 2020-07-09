using ExternalServices;
using Microsoft.Extensions.DependencyInjection;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public static class ConfigureServiceExtensions
    {
        public static void ConfigureServicesExtensions(this IServiceCollection services)
        {
            services.AddTransient<IFinanceiroService, FinanceiroService>();
            services.AddTransient<IMetadataService, MetadataService>();

            services.ConfigureExternalServicesExtensions();
        }

    }
}
