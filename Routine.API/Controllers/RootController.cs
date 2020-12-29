using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Routine.API.Models;

namespace Routine.API.Controllers
{
    [ApiController]
    [Route("api")]
    public class RootController : ControllerBase
    {
        [HttpGet(Name = nameof(GetRoot))]
        public IActionResult GetRoot()
        {

            var links = new List<LinkDto>
            {
                new LinkDto(Url.Link(nameof(GetRoot), new { }), "self", "GET"),
                new LinkDto(Url.Link(nameof(CompaniesController.GetCompanies), new { }), "companies", "GET"),
                new LinkDto(Url.Link(nameof(CompaniesController.CreateCompany), new { }), "create_company",
                    "POST")
            };

            return Ok(links);
        }

    }
}