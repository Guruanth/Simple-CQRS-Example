using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cqrs.Contracts;
using Cqrs.Dal.Query.Api;
using Cqrs.Dal.Query.Api.People;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Cqrs.Web.Controllers
{
    [Route("api/[controller]")]
    public class PeopleController : Controller
    {
        private readonly IQueryDispatcher _queryRunner;

        public PeopleController(IQueryDispatcher queryRunner)
        {
            _queryRunner = queryRunner;
        }

        // GET api/people
        [HttpGet]
        public IEnumerable<PersonResponse> Get()
        {
            return _queryRunner.Dispatch(new PeopleResponseQuery());
        }

        // GET api/people/5
        [HttpGet("{id}")]
        public PersonResponse Get(int id)
        {
            return _queryRunner.Dispatch(new PersonResponseQuery(id));
        }

        // POST api/people
        [HttpPost]
        public void Post([FromBody]string person)
        {
        }

        // PUT api/people/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string person)
        {
        }

        // DELETE api/people/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}