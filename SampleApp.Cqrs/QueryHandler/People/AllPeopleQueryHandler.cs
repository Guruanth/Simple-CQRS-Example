using Microsoft.Extensions.Logging;
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
        public AllPeopleQueryHandler(SampleAppContext context, ILogger logger) : base(context, logger)
        {
        }

        protected override List<PersonQueryResult> RunQueryInternal(AllPeopleQuery query)
        {
            Logger.LogInformation("AllPeopleQueryHandler.RunQueryInternal");

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