using SampleApp.Cqrs.Query;
using SampleApp.Cqrs.Query.Companies;
using SampleApp.Cqrs.QueryResult;
using SampleApp.Dal.Infrastructure;
using SampleApp.Dal.Models;
using System.Linq;

namespace SampleApp.Cqrs.QueryHandler.Companies
{
    public class CompanyByIdQueryHandler : QueryHandlerBase<CompanyByIdQuery, CompanyQueryResult, Company>
    {
        public CompanyByIdQueryHandler(IDbContextQuery dbContext) : base(dbContext)
        {
        }

        protected override CompanyQueryResult RunQueryInternal(CompanyByIdQuery query)
        {
            return DbSet.Where(x => x.Id == query.CompanyId)
                              .Select(o => new CompanyQueryResult
                              {
                                  Id = o.Id,
                                  Name = o.Name
                              })
                              .SingleOrDefault();
        }
    }
}