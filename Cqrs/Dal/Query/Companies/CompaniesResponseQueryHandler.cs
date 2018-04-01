using Cqrs.BusinessObjects;
using Cqrs.Contracts;
using Cqrs.Dal.Infrastructure;
using Cqrs.Dal.Query.Api.Companies;
using System.Collections.Generic;
using System.Linq;

namespace Cqrs.Dal.Query.Companies
{
    public class CompaniesResponseQueryHandler : QueryHandlerBase<CompaniesResponseQuery, List<CompanyResponse>, Company>
    {
        public CompaniesResponseQueryHandler(IDbContextQuery dbContext) : base(dbContext)
        {
        }

        protected override List<CompanyResponse> RunQueryInternal(CompaniesResponseQuery query)
        {
            return DbSet.Select(o => new CompanyResponse
            {
                Id = o.Id,
                Name = o.Name
            })
            .ToList();
        }
    }
}