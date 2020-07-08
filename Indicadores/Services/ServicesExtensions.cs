using Microsoft.Extensions.DependencyInjection;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public static class ServicesExtensions
    {
        public static void ConfigureServicesExtensions(this IServiceCollection services)
        {
            services.AddSingleton<ITaxasService, TaxaService>();
        }
    }
}
