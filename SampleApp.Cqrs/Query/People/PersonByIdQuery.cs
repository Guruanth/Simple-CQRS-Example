using SampleApp.Cqrs.Query;
using SampleApp.Cqrs.QueryResult;

namespace SampleApp.Cqrs.Query.People
{
    public class PersonByIdQuery : IQuery<PersonQueryResult>
    {
        public int PersonId { get; }

        public PersonByIdQuery(int personId)
        {
            PersonId = personId;
        }
    }
}