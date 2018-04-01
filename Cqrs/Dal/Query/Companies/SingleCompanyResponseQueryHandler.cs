using Cqrs.BusinessObjects;
using Cqrs.Contracts;
using Cqrs.Dal.Infrastructure;
using Cqrs.Dal.Query.Api.Companies;
using System.Linq;

namespace Cqrs.Dal.Query.Companies
{
    public class SingleCompanyResponseQueryHandler : QueryHandlerBase<CompanyResponseQuery, CompanyResponse, Company>
    {
        public SingleCompanyResponseQueryHandler(IDbContextQuery dbContext) : base(dbContext)
        {
        }

        protected override CompanyResponse RunQueryInternal(CompanyResponseQuery query)
        {
            return DbSet.Where(x => x.Id == query.CompanyId)
                              .Select(o => new CompanyResponse
                              {
                                  Id = o.Id,
                                  Name = o.Name
                              })
                              .SingleOrDefault();
        }
    }
}