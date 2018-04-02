using SampleApp.Cqrs.Query;

namespace SampleApp.Cqrs.QueryResult
{
    /// <summary>
    /// Represents what will be shown in the UI
    /// </summary>
    public class PersonQueryResult : IQueryResult
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Country { get; set; }
    }
}