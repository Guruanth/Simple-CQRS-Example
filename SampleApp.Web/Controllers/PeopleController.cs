using Microsoft.AspNetCore.Mvc;
using SampleApp.Cqrs.Command.Companies;
using SampleApp.Cqrs.Dispatchers;
using SampleApp.Cqrs.Dto;
using SampleApp.Cqrs.Query.People;
using SampleApp.Cqrs.QueryResult;
using System.Collections.Generic;

namespace SampleApp.Web.Controllers
{
    [Route("api/[controller]")]
    public class PeopleController : Controller
    {
        private readonly IQueryDispatcher _queryRunner;
        private readonly ICommandDispatcher _commandDispatcher;

        public PeopleController(IQueryDispatcher queryRunner, ICommandDispatcher commandDispatcher)
        {
            _queryRunner = queryRunner;
            _commandDispatcher = commandDispatcher;
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
        public void Post([FromBody]PersonDto personDto)
        {
            _commandDispatcher.Dispatch(new AddPersonCommand(personDto));
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