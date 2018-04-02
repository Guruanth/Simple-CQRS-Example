using SampleApp.Cqrs.QueryResult;
using System.Collections.Generic;

namespace SampleApp.Cqrs.Query.People
{
    public class AllPeopleQuery : IQuery<List<PersonQueryResult>>
    {
    }
}