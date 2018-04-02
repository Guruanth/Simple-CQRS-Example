using SampleApp.Cqrs.QueryResult;

namespace SampleApp.Cqrs.Query.Companies
{
    public class CompanyByIdQuery : IQuery<CompanyQueryResult>
    {
        public int CompanyId { get; }

        public CompanyByIdQuery(int companyId)
        {
            CompanyId = companyId;
        }
    }
}