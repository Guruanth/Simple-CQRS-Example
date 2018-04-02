using SampleApp.Cqrs.Query;

namespace SampleApp.Cqrs.QueryResult
{
    /// <summary>
    /// Represents what will be shown in the UI
    /// </summary>
    public class CompanyQueryResult : IQueryResult
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}