using Microsoft.Extensions.Logging;
using SampleApp.Dal.Models;
using System.Linq;

namespace SampleApp.Dal.Infrastructure
{
    public static class DbInitializer
    {
        public static void Initialize(SampleAppContext context)
        {
            context.Database.EnsureCreated();

            if (context.People.Any())
                return;

            var people = new Person[]
            {
                new Person{ FirstName = "Bill", LastName="Gates", Country = "USA", PhoneNumber = "123 456 789"},
                new Person{ FirstName = "Mark", LastName="Zuckerberg", Country = "USA", PhoneNumber = "987 654 321"},
                new Person{ FirstName = "Steve", LastName="Jobs", Country = "USA", PhoneNumber = "456 123 789"},
                new Person{ FirstName = "Sergey", LastName="Brin", Country = "Russia", PhoneNumber = "465 987 132"},
                new Person{ FirstName = "Larry", LastName="Page", Country = "USA", PhoneNumber = "654 123 897"},
                new Person{ FirstName = "Paul", LastName="Allen", Country = "USA", PhoneNumber = "897 564 321"},
                new Person{ FirstName = "Jeff", LastName="Bezos", Country = "USA", PhoneNumber = "132 586 789"},
                new Person{ FirstName = "Steve", LastName="Ballmer", Country = "USA", PhoneNumber = "978 645 321"},
                new Person{ FirstName = "Nikola", LastName="Tesla", Country = "Serbia", PhoneNumber = "132 897 465"},
                new Person{ FirstName = "Tomas", LastName="Bata", Country = "Czech Republic", PhoneNumber = "321 654 897"}
            };

            context.People.AddRange(people);

            var companies = new Company[]
            {
                new Company { Name = "Microsoft"},
                new Company { Name = "Apple"},
                new Company { Name = "Facebook"},
                new Company { Name = "Google"},
                new Company { Name = "Amazon"},
            };

            context.Companies.AddRange(companies);

            context.SaveChanges();
        }
    }
}