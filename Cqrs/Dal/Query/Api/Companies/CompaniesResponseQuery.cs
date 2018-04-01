using Cqrs.Contracts;
using System.Collections.Generic;

namespace Cqrs.Dal.Query.Api.Companies
{
    public class CompaniesResponseQuery : IQuery<List<CompanyResponse>>
    {
    }
}