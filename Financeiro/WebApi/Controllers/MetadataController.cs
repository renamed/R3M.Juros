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
    public class MetadataController : Controller
    {
        private readonly IMetadataService _githubService;

        public MetadataController(IMetadataService githubService)
        {
            _githubService = githubService;
        }

        [HttpGet("code")]
        public IActionResult GetCodeRepositoryUrl()
        {
            return Ok(new CodeRepositoryResponse
            {
                Url = _githubService.GetCodeRepositoryUrl()
            });
        }
    }
}