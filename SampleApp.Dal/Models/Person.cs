﻿using System.ComponentModel.DataAnnotations;

namespace SampleApp.Dal.Models
{
    public class Person
    {
        [Key]
        public int Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Country { get; set; }
    }
}