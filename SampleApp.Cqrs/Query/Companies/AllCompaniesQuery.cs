using SampleApp.Cqrs.QueryResult;
using System.Collections.Generic;

namespace SampleApp.Cqrs.Query.Companies
{
    public class AllCompaniesQuery : IQuery<List<CompanyQueryResult>>
    {
    }
}