using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Routine.API.Entities;
using Routine.API.Helpers;
using Routine.API.Models;
using Routine.API.Services;

namespace Routine.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyCollectionsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICompanyRepository _companyRepository;

        public CompanyCollectionsController(IMapper mapper,ICompanyRepository companyRepository)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _companyRepository = companyRepository ?? throw new ArgumentNullException(nameof(companyRepository));
        }

        //1,2,3,4
        //KeyValuePair  key1=value1 ,key2=value2

        [HttpGet("({ids})",Name = nameof(GetCompanyCollection))]
        public async Task<ActionResult<IEnumerable<CompanyDto>>> GetCompanyCollection(
            [FromRoute] 
            [ModelBinder(BinderType = typeof(ArrayModelBinder))]
            IEnumerable<Guid> ids)
        {
            if (ids ==null)
            {
                return BadRequest();
            }
            
            var entities = await _companyRepository.GetCompaniesAsync(ids);
            if (ids.Count() !=entities.Count())
            {
                return NotFound();
            }

            var dtoToReturn = _mapper.Map<IEnumerable<CompanyDto>>(entities);
            return Ok(dtoToReturn);
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<CompanyDto>>> CreateCompanyCollection(IEnumerable<CompanyAddDto> companyCollection)
        {
            var companyEntities = _mapper.Map<IEnumerable<Company>>(companyCollection);
            foreach (var company in companyEntities)
            {
                _companyRepository.AddCompany(company);
            }

            await _companyRepository.SaveAsync();
            var dtosToReturn = _mapper.Map<IEnumerable<CompanyDto>>(companyEntities);
            var idsString = string.Join(",", dtosToReturn.Select(x => x.Id));

            return CreatedAtRoute(nameof(GetCompanyCollection), new {ids = idsString}, dtosToReturn);
        }
    }
}
