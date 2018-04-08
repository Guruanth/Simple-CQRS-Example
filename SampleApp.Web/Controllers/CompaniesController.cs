using Microsoft.AspNetCore.Mvc;
using SampleApp.Cqrs.Command.Companies;
using SampleApp.Cqrs.Dispatchers;
using SampleApp.Cqrs.Dto;
using SampleApp.Cqrs.Query.Companies;
using SampleApp.Cqrs.QueryResult;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SampleApp.Web.Controllers
{
    [Route("api/[controller]")]
    public class CompaniesController : Controller
    {
        private readonly IQueryDispatcher _queryDispatcher;
        private readonly ICommandDispatcher _commandDispatcher;

        public CompaniesController(IQueryDispatcher queryDispatcher, ICommandDispatcher commandDispatcher)
        {
            _queryDispatcher = queryDispatcher;
            _commandDispatcher = commandDispatcher;
        }

        // GET api/companies
        [HttpGet]
        public IEnumerable<CompanyQueryResult> Get()
        {
            return _queryDispatcher.Dispatch(new AllCompaniesQuery());
        }

        // GET api/companies/5
        [HttpGet("{id}")]
        public CompanyQueryResult Get(int id)
        {
            return _queryDispatcher.Dispatch(new CompanyByIdQuery(id));
        }

        // POST api/companies
        [HttpPost]
        public IActionResult Post([FromBody]CompanyDto companyDto)
        {
            _commandDispatcher.Dispatch(new AddCompanyCommand(companyDto));

            return Ok();
        }

        // PUT api/companies/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]CompanyDto companyDto)
        {
            var companyResult = _queryDispatcher.Dispatch(new CompanyByIdQuery(id));

            if (companyResult == null)
            {
                return NotFound(id);
            }

            if (await TryUpdateModelAsync(companyResult))
            {
                _commandDispatcher.Dispatch(new UpdateCompanyCommand(id, companyDto));
            }

            return Ok();
        }

        // DELETE api/companies/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _commandDispatcher.Dispatch(new DeleteCompanyCommand(id));

            return Ok();
        }
    }
}