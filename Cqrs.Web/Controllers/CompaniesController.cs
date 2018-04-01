using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cqrs.Contracts;
using Cqrs.Dal.Query.Api;
using Cqrs.Dal.Query.Api.Companies;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Cqrs.Web.Controllers
{
    [Route("api/[controller]")]
    public class CompaniesController : Controller
    {
        private readonly IQueryExecuter _queryExecuter;

        public CompaniesController(IQueryExecuter queryExecuter)
        {
            _queryExecuter = queryExecuter;
        }

        // GET api/companies
        [HttpGet]
        public IEnumerable<CompanyResponse> Get()
        {
            return _queryExecuter.Send(new CompaniesResponseQuery());
        }

        // GET api/companies/5
        [HttpGet("{id}")]
        public CompanyResponse Get(int id)
        {
            return _queryExecuter.Send(new CompanyResponseQuery(id));
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