using Microsoft.AspNetCore.Mvc;
using SampleApp.Cqrs.Query;
using SampleApp.Cqrs.Query.Companies;
using SampleApp.Cqrs.QueryResult;
using System.Collections.Generic;

namespace SampleApp.Web.Controllers
{
    [Route("api/[controller]")]
    public class CompaniesController : Controller
    {
        private readonly IQueryDispatcher _queryRunner;

        public CompaniesController(IQueryDispatcher queryRunner)
        {
            _queryRunner = queryRunner;
        }

        // GET api/companies
        [HttpGet]
        public IEnumerable<CompanyQueryResult> Get()
        {
            return _queryRunner.Dispatch(new AllCompaniesQuery());
        }

        // GET api/companies/5
        [HttpGet("{id}")]
        public CompanyQueryResult Get(int id)
        {
            return _queryRunner.Dispatch(new CompanyByIdQuery(id));
        }

        // POST api/companies
        [HttpPost]
        public void Post([FromBody]string company)
        {
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