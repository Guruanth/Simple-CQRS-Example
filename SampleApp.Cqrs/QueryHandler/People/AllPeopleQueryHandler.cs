using SampleApp.Cqrs.Query.People;
using SampleApp.Cqrs.QueryResult;
using SampleApp.Dal.Infrastructure;
using SampleApp.Dal.Models;
using System.Collections.Generic;
using System.Linq;

namespace SampleApp.Cqrs.QueryHandler.People
{
    public class AllPeopleQueryHandler : QueryHandlerBase<AllPeopleQuery, List<PersonQueryResult>, Person>
    {
        public AllPeopleQueryHandler(SampleAppContext context) : base(context)
        {
        }

        protected override List<PersonQueryResult> RunQueryInternal(AllPeopleQuery query)
        {
            return DbSet.Select(o => new PersonQueryResult
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