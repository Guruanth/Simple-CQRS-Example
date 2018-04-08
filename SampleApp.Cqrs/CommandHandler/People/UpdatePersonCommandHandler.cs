using SampleApp.Cqrs.Command.People;
using SampleApp.Dal.Infrastructure;
using SampleApp.Dal.Models;

namespace SampleApp.Cqrs.CommandHandler.People
{
    public class UpdatePersonCommandHandler : CommandHandlerBase<UpdatePersonCommand, Person>
    {
        public UpdatePersonCommandHandler(SampleAppContext context) : base(context)
        {
        }

        protected override void RunCommandInternal(UpdatePersonCommand command)
        {
            var person = new Person
            {
                Id = command.Id,
                FirstName = command.PersonDto.FirstName,
                LastName = command.PersonDto.LastName,
                PhoneNumber = command.PersonDto.PhoneNumber,
                Country = command.PersonDto.Country
            };

            Repository.Update(person);
            SaveChanges();
        }
    }
}