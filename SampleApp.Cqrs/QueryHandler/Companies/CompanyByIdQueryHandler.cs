using Microsoft.Extensions.Logging;
using SampleApp.Cqrs.Query.Companies;
using SampleApp.Cqrs.QueryResult;
using SampleApp.Dal.Infrastructure;
using SampleApp.Dal.Models;
using System.Linq;

namespace SampleApp.Cqrs.QueryHandler.Companies
{
    public class CompanyByIdQueryHandler : QueryHandlerBase<CompanyByIdQuery, CompanyQueryResult, Company>
    {
        public CompanyByIdQueryHandler(SampleAppContext context, ILogger logger) : base(context, logger)
        {
        }

        protected override CompanyQueryResult RunQueryInternal(CompanyByIdQuery query)
        {
            Logger.LogInformation("CompanyByIdQueryHandler.RunQueryInternal");

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