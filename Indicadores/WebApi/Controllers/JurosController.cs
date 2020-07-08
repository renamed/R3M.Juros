using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    public class JurosController : Controller
    {
        private readonly ITaxasService _taxaService;

        public JurosController(ITaxasService taxaService)
        {
            _taxaService = taxaService;
        }

        [HttpGet("taxa")]
        public IActionResult GetTaxaJuros()
        {
            return Ok(new TaxaJurosResponse {
                Taxa = _taxaService.GetTaxaJuros()
            });
        }
    }
}
