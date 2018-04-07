using SampleApp.Dal.Models;
using System.Linq;

namespace SampleApp.Dal.Infrastructure
{
    public static class DbInitializer
    {
        public static void Initialize(AppContext context)
        {
            context.Database.EnsureCreated();

            if (context.People.Any())
                return;

            var people = new Person[]
            {
                new Person{ Id = 1, FirstName = "Bill", LastName="Gates", Country = "USA", PhoneNumber = "123 456 789"},
                new Person{ Id = 2, FirstName = "Mark", LastName="Zuckerberg", Country = "USA", PhoneNumber = "987 654 321"},
                new Person{ Id = 3, FirstName = "Steve", LastName="Jobs", Country = "USA", PhoneNumber = "456 123 789"},
                new Person{ Id = 4, FirstName = "Sergey", LastName="Brin", Country = "Russia", PhoneNumber = "465 987 132"},
                new Person{ Id = 5, FirstName = "Larry", LastName="Page", Country = "USA", PhoneNumber = "654 123 897"},
                new Person{ Id = 6, FirstName = "Paul", LastName="Allen", Country = "USA", PhoneNumber = "897 564 321"},
                new Person{ Id = 7, FirstName = "Jeff", LastName="Bezos", Country = "USA", PhoneNumber = "132 586 789"},
                new Person{ Id = 8, FirstName = "Steve", LastName="Ballmer", Country = "USA", PhoneNumber = "978 645 321"},
                new Person{ Id = 9, FirstName = "Nikola", LastName="Tesla", Country = "Serbia", PhoneNumber = "132 897 465"},
                new Person{ Id = 10, FirstName = "Tomas", LastName="Bata", Country = "Czech Republic", PhoneNumber = "321 654 897"}
            };

            context.People.AddRange(people);

            var companies = new Company[]
            {
                new Company { Id = 1, Name = "Microsoft"},
                new Company { Id = 2, Name = "Apple"},
                new Company { Id = 3, Name = "Facebook"},
                new Company { Id = 4, Name = "Google"},
                new Company { Id = 5, Name = "Amazon"},
            };

            context.Companies.AddRange(companies);

            context.SaveChanges();
        }
    }
}