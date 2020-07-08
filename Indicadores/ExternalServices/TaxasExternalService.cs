using ExternalServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExternalServices
{
    public class TaxasExternalService : ITaxasExternalService
    {
        public decimal GetTaxaJuros()
        {
            return 0.01M;
        }
    }
}
