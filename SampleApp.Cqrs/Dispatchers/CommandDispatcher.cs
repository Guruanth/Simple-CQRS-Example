using Microsoft.Extensions.DependencyInjection;
using SampleApp.Cqrs.Command;
using SampleApp.Cqrs.CommandHandler;
using SampleApp.Dal.Infrastructure;
using System;

namespace SampleApp.Cqrs.Dispatchers
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly SampleAppContext _context;
        private readonly IServiceProvider _serviceProvider;

        public CommandDispatcher(SampleAppContext context, IServiceProvider serviceProvider)
        {
            _context = context;
            _serviceProvider = serviceProvider;
        }

        public void Dispatch<TParameter>(TParameter command) where TParameter : ICommand
        {
            RunCommand(command);
        }

        private void RunCommand<TParameter>(TParameter command) where TParameter : ICommand
        {
            var commandHandler = _serviceProvider.GetService<ICommandHandler<TParameter>>();

            if (commandHandler == null)
            {
                throw new ArgumentException("Handler not registered for type " + typeof(TParameter).Name);
            }

            commandHandler.RunCommand(command);
        }
    }
}