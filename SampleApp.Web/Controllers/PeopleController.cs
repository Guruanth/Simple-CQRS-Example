using Microsoft.AspNetCore.Mvc;
using SampleApp.Cqrs.Command.People;
using SampleApp.Cqrs.Dispatchers;
using SampleApp.Cqrs.Dto;
using SampleApp.Cqrs.Query.People;
using SampleApp.Cqrs.QueryResult;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SampleApp.Web.Controllers
{
    [Route("api/[controller]")]
    public class PeopleController : Controller
    {
        private readonly IQueryDispatcher _queryDispatcher;
        private readonly ICommandDispatcher _commandDispatcher;

        public PeopleController(IQueryDispatcher queryRunner, ICommandDispatcher commandDispatcher)
        {
            _queryDispatcher = queryRunner;
            _commandDispatcher = commandDispatcher;
        }

        // GET api/people
        [HttpGet]
        public IEnumerable<PersonQueryResult> Get()
        {
            return _queryDispatcher.Dispatch(new AllPeopleQuery());
        }

        // GET api/people/5
        [HttpGet("{id}")]
        public PersonQueryResult Get(int id)
        {
            return _queryDispatcher.Dispatch(new PersonByIdQuery(id));
        }

        // POST api/people
        [HttpPost]
        public IActionResult Post([FromBody]PersonDto personDto)
        {
            _commandDispatcher.Dispatch(new AddPersonCommand(personDto));

            return Ok();
        }

        // PUT api/people/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]PersonDto personDto)
        {
            var personResult = _queryDispatcher.Dispatch(new PersonByIdQuery(id));

            if (personResult == null)
            {
                return NotFound(id);
            }

            if (await TryUpdateModelAsync(personResult))
            {
                _commandDispatcher.Dispatch(new UpdatePersonCommand(id, personDto));
            }

            return Ok();
        }

        // DELETE api/people/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _commandDispatcher.Dispatch(new DeletePersonCommand(id));

            return Ok();
        }
    }
}