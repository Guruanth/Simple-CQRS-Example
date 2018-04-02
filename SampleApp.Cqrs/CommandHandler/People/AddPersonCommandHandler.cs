using SampleApp.Cqrs.Command.Companies;
using SampleApp.Dal.Infrastructure;
using SampleApp.Dal.Models;

namespace SampleApp.Cqrs.CommandHandler.Companies
{
    public class AddPersonCommandHandler : CommandHandlerBase<AddPersonCommand, Person>
    {
        public AddPersonCommandHandler(IDbContextQuery dbContext) : base(dbContext)
        {
        }

        protected override void RunCommandInternal(AddPersonCommand command)
        {
            // NOTE: This code doesn't actually do anything since we don't have a real DB

            var companyDto = command.PersonDto;

            // TODO: Add business logic here

            // TODO: Add DB code here
        }
    }
}