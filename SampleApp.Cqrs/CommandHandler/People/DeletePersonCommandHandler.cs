using SampleApp.Cqrs.Command.People;
using SampleApp.Dal.Infrastructure;
using SampleApp.Dal.Models;

namespace SampleApp.Cqrs.CommandHandler.People
{
    public class DeletePersonCommandHandler : CommandHandlerBase<DeletePersonCommand, Person>
    {
        public DeletePersonCommandHandler(SampleAppContext context) : base(context)
        {
        }

        protected override void RunCommandInternal(DeletePersonCommand command)
        {
            var person = new Person
            {
                Id = command.Id
            };

            Repository.Delete(person);
            SaveChanges();
        }
    }
}