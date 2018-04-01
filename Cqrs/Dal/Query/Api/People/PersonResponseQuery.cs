using Cqrs.Contracts;

namespace Cqrs.Dal.Query.Api.People
{
    public class PersonResponseQuery : IQuery<PersonResponse>
    {
        public int PersonId { get; }

        public PersonResponseQuery(int personId)
        {
            PersonId = personId;
        }
    }
}