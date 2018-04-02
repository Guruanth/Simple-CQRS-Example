﻿namespace SampleApp.Dal.Models
{
    /// <summary>
    /// Represents the Person table on the DB
    /// </summary>
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Country { get; set; }
    }
}