using SampleApp.Cqrs.Command;
using SampleApp.Dal.Infrastructure;
using System.Collections.Generic;

namespace SampleApp.Cqrs.CommandHandler
{
    public abstract class CommandHandlerBase<TCommand, TAggregateRoot> : ICommandHandler<TCommand>
        where TCommand : ICommand
        where TAggregateRoot : class
    {
        private readonly IDbContextQuery _dbContext;

        protected CommandHandlerBase(IDbContextQuery dbContext)
        {
            _dbContext = dbContext;
        }

        protected IEnumerable<TAggregateRoot> DbSet
        {
            get
            {
                return _dbContext.GetQuery<TAggregateRoot>();
            }
        }

        protected IEnumerable<TEntity> GetSet<TEntity>() where TEntity : class
        {
            return _dbContext.GetQuery<TEntity>();
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