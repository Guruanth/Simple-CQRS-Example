using SampleApp.Cqrs.CommandHandler;
using SampleApp.Cqrs.CommandHandler.Companies;
using SampleApp.Dal.Infrastructure;

namespace SampleApp.Cqrs.Command
{
    public class CommandDispatcher : ICommandDispatcher
    {
        public void Dispatch<TParameter>(TParameter command) where TParameter : ICommand
        {
            RunCommand(command);
        }

        private void RunCommand<TParameter>(TParameter command) where TParameter : ICommand
        {
            var ctx = new DbContextQuery();
            var commandHandler = (ICommandHandler<TParameter>)new AddPersonCommandHandler(ctx);

            commandHandler.RunCommand(command);
        }
    }
}