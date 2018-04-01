namespace Cqrs.Contracts
{
    /// <summary>
    /// Represents what will be shown in the UI
    /// </summary>
    public class PersonResponse
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Country { get; set; }
    }
}