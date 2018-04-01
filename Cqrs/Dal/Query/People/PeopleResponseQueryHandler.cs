using Cqrs.BusinessObjects;
using Cqrs.Contracts;
using Cqrs.Dal.Infrastructure;
using Cqrs.Dal.Query.Api.People;
using System.Collections.Generic;
using System.Linq;

namespace Cqrs.Dal.Query.People
{
    public class PeopleResponseQueryHandler : QueryHandlerBase<PeopleResponseQuery, List<PersonResponse>, Person>
    {
        public PeopleResponseQueryHandler(IDbContextQuery dbContext) : base(dbContext)
        {
        }

        protected override List<PersonResponse> RunQueryInternal(PeopleResponseQuery query)
        {
            return DbSet.Select(o => new PersonResponse
            {
                Id = o.Id,
                FirstName = o.FirstName,
                LastName = o.LastName,
                Country = o.Country,
                PhoneNumber = o.PhoneNumber
            })
            .ToList();
        }
    }
}