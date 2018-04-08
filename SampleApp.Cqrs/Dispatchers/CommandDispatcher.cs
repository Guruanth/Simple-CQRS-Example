using SampleApp.Cqrs.Command;
using SampleApp.Cqrs.Command.Companies;
using SampleApp.Cqrs.CommandHandler;
using SampleApp.Cqrs.CommandHandler.Companies;
using SampleApp.Dal.Infrastructure;
using System;

namespace SampleApp.Cqrs.Dispatchers
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly SampleAppContext _context;

        public CommandDispatcher(SampleAppContext context)
        {
            _context = context;
        }

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
        /// <returns></returns>
        private ICommandHandler<TParameter> GetCommandHandler<TParameter>() where TParameter : ICommand
        {
            ICommandHandler<TParameter> commandHandler;
            if (typeof(TParameter) == typeof(AddPersonCommand))
            {
                commandHandler = (ICommandHandler<TParameter>)new AddPersonCommandHandler(_context);
            }
            else if (typeof(TParameter) == typeof(AddCompanyCommand))
            {
                commandHandler = (ICommandHandler<TParameter>)new AddCompanyCommandHandler(_context);
            }
            else
            {
                throw new Exception("Invalid type.");
            }

            return commandHandler;
        }
    }
}