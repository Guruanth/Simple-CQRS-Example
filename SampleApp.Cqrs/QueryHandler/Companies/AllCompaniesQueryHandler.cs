using SampleApp.Cqrs.Query.Companies;
using SampleApp.Cqrs.QueryResult;
using SampleApp.Dal.Infrastructure;
using SampleApp.Dal.Models;
using System.Collections.Generic;
using System.Linq;

namespace SampleApp.Cqrs.QueryHandler.Companies
{
    public class AllCompaniesQueryHandler : QueryHandlerBase<AllCompaniesQuery, List<CompanyQueryResult>, Company>
    {
        public AllCompaniesQueryHandler(SampleAppContext context) : base(context)
        {
        }

        protected override List<CompanyQueryResult> RunQueryInternal(AllCompaniesQuery query)
        {
            return DbSet.Select(o => new CompanyQueryResult
            {
                Id = o.Id,
                Name = o.Name
            })
            .ToList();
        }
    }
}