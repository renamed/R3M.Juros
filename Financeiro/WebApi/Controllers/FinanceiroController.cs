using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using WebApi.Model;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    public class FinanceiroController : Controller
    {
        private readonly IFinanceiroService _financeiroService;

        public FinanceiroController(IFinanceiroService financeiroService)
        {
            _financeiroService = financeiroService;
        }

        [HttpGet("juros/compostos")]
        public async Task<IActionResult> CalcularValorJuros(CalculoValorJurosRequest request)
        {
            try
            {
                var valorFinal = await _financeiroService.CalcularJurosCompostos(request.ValorInicial, request.QtdMeses);

                return Ok(new CalculoValorJurosResponse
                {
                    ValorFinal = Math.Truncate(100 * valorFinal) / 100
                });
            }
            catch (ValidationException valEx)
            {
                return BadRequest(valEx.Message);
            }
        }
    }
}
