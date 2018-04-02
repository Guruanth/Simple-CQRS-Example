using Microsoft.AspNetCore.Mvc;
using SampleApp.Cqrs.Query;
using SampleApp.Cqrs.Query.People;
using SampleApp.Cqrs.QueryResult;
using System.Collections.Generic;

namespace SampleApp.Web.Controllers
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
        public IEnumerable<PersonQueryResult> Get()
        {
            return _queryRunner.Dispatch(new AllPeopleQuery());
        }

        // GET api/people/5
        [HttpGet("{id}")]
        public PersonQueryResult Get(int id)
        {
            return _queryRunner.Dispatch(new PersonByIdQuery(id));
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