using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class TaxaService : ITaxasService
    {
        public decimal GetTaxaJuros()
        {
            return 0.01M;
        }
    }
}
