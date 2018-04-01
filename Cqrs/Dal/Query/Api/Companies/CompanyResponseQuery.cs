using Cqrs.Contracts;

namespace Cqrs.Dal.Query.Api.Companies
{
    public class CompanyResponseQuery : IQuery<CompanyResponse>
    {
        public int CompanyId { get; }

        public CompanyResponseQuery(int companyId)
        {
            CompanyId = companyId;
        }
    }
}