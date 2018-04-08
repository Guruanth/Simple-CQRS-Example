using SampleApp.Cqrs.Query.People;
using SampleApp.Cqrs.QueryResult;
using SampleApp.Dal.Infrastructure;
using SampleApp.Dal.Models;
using System.Linq;

namespace SampleApp.Cqrs.QueryHandler.People
{
    public class PersonByIdQueryHandler : QueryHandlerBase<PersonByIdQuery, PersonQueryResult, Person>
    {
        public PersonByIdQueryHandler(SampleAppContext context) : base(context)
        {
        }

        protected override PersonQueryResult RunQueryInternal(PersonByIdQuery query)
        {
            return DbSet.Where(x => x.Id == query.PersonId)
                              .Select(o => new PersonQueryResult
                              {
                                  Id = o.Id,
                                  FirstName = o.FirstName,
                                  LastName = o.LastName,
                                  Country = o.Country,
                                  PhoneNumber = o.PhoneNumber
                              })
                              .SingleOrDefault();
        }
    }
}