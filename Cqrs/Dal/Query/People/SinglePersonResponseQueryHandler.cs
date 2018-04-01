using Cqrs.BusinessObjects;
using Cqrs.Contracts;
using Cqrs.Dal.Infrastructure;
using Cqrs.Dal.Query.Api;
using Cqrs.Dal.Query.Api.People;
using System.Linq;

namespace Cqrs.Dal.Query.People
{
    public class SinglePersonResponseQueryHandler : QueryHandlerBase<PersonResponseQuery, PersonResponse, Person>
    {
        public SinglePersonResponseQueryHandler(IDbContextQuery dbContext) : base(dbContext)
        {
        }

        protected override PersonResponse RunQueryInternal(PersonResponseQuery query)
        {
            return DbSet.Where(x => x.Id == query.PersonId)
                              .Select(o => new PersonResponse
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