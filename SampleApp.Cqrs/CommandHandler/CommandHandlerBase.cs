using SampleApp.Cqrs.Command;
using SampleApp.Dal.Infrastructure;
using System.Linq;

namespace SampleApp.Cqrs.CommandHandler
{
    public abstract class CommandHandlerBase<TCommand, TAggregateRoot> : ICommandHandler<TCommand>
        where TCommand : ICommand
        where TAggregateRoot : class
    {
        private readonly SampleAppContext _context;

        protected CommandHandlerBase(SampleAppContext context)
        {
            _context = context;
        }

        protected IQueryable<TAggregateRoot> DbSet
        {
            get
            {
                return _context.Set<TAggregateRoot>();
            }
        }

        protected IQueryable<TEntity> GetSet<TEntity>() where TEntity : class
        {
            return _context.Set<TEntity>();
        }

        /// <summary>
        /// Execute the command against the database
        /// </summary>
        /// <param name="command"></param>
        protected abstract void RunCommandInternal(TCommand command);

        public void RunCommand(TCommand command)
        {
            RunCommandInternal(command);
        }
    }
}