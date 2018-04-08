using SampleApp.Cqrs.Command.Companies;
using SampleApp.Dal.Infrastructure;
using SampleApp.Dal.Models;

namespace SampleApp.Cqrs.CommandHandler.Companies
{
    public class AddPersonCommandHandler : CommandHandlerBase<AddPersonCommand, Person>
    {
        public AddPersonCommandHandler(SampleAppContext context) : base(context)
        {
        }

        protected override void RunCommandInternal(AddPersonCommand command)
        {
            var person = new Person
            {
                FirstName = command.PersonDto.FirstName,
                LastName = command.PersonDto.LastName,
                PhoneNumber = command.PersonDto.PhoneNumber,
                Country = command.PersonDto.Country
            };

            Repository.Insert(person);
            SaveChanges();
        }
    }
}