using SampleApp.Dal.Infrastructure;
using System.Collections.Generic;

namespace SampleApp.Cqrs.Query
{
    public abstract class QueryHandlerBase<TQuery, TResult, TAggregateRoot> : IQueryHandler<TQuery, TResult>
        where TQuery : IQuery<TResult>
        where TAggregateRoot : class
    {
        private readonly IDbContextQuery _dbContext;

        protected QueryHandlerBase(IDbContextQuery dbContext)
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
        /// Query to be executed against the database
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        protected abstract TResult RunQueryInternal(TQuery query);

        public TResult RunQuery(IQuery<TResult> query)
        {
            return RunQueryInternal((TQuery)query);
        }
    }
}