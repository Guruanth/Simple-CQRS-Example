using SampleApp.Cqrs.Command.Companies;
using SampleApp.Cqrs.CommandHandler;
using SampleApp.Cqrs.CommandHandler.Companies;
using SampleApp.Dal.Infrastructure;
using System;

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
            var commandHandler = GetCommandHandler<TParameter>();

            commandHandler.RunCommand(command);
        }

        /// <summary>
        /// Ignore this. It's clearly the WORST possible thing to do. But it works for this example
        /// </summary>
        /// <typeparam name="TParameter"></typeparam>
        /// <param name="ctx"></param>
        /// <returns></returns>
        private ICommandHandler<TParameter> GetCommandHandler<TParameter>() where TParameter : ICommand
        {
            var ctx = new DbContextQuery();
            ICommandHandler<TParameter> commandHandler;
            if (typeof(TParameter) == typeof(AddPersonCommand))
            {
                commandHandler = (ICommandHandler<TParameter>)new AddPersonCommandHandler(ctx);
            }
            else if (typeof(TParameter) == typeof(AddCompanyCommand))
            {
                commandHandler = (ICommandHandler<TParameter>)new AddCompanyCommandHandler(ctx);
            }
            else
            {
                throw new Exception("Invalid type.");
            }

            return commandHandler;
        }
    }
}