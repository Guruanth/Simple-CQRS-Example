using SampleApp.Cqrs.Query;
using SampleApp.Dal.Infrastructure;
using System.Linq;

namespace SampleApp.Cqrs.QueryHandler
{
    public abstract class QueryHandlerBase<TQuery, TResult, TAggregateRoot> : IQueryHandler<TQuery, TResult>
        where TQuery : IQuery<TResult>
        where TAggregateRoot : class
    {
        private readonly SampleAppContext _context;

        protected QueryHandlerBase(SampleAppContext context)
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