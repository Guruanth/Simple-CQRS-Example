using Microsoft.AspNetCore.Mvc;
using SampleApp.Cqrs.Command.Companies;
using SampleApp.Cqrs.Dispatchers;
using SampleApp.Cqrs.Dto;
using SampleApp.Cqrs.Query.Companies;
using SampleApp.Cqrs.QueryResult;
using System.Collections.Generic;

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
        public void Post([FromBody]CompanyDto companyDto)
        {
            _commandDispatcher.Dispatch(new AddCompanyCommand(companyDto));
        }

        // PUT api/companies/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string company)
        {
        }

        // DELETE api/companies/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}