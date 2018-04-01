using Cqrs.Dal.Query.Api;

namespace Cqrs.Dal.Query
{
    public interface IQueryHandler<TResult> : IQueryHandler
    {
        TResult RunQuery(IQuery<TResult> query);
    }

    public interface IQueryHandler<TQuery, TResult> : IQueryHandler<TResult> where TQuery : IQuery<TResult>
    {
    }

    public interface IQueryHandler
    {
    }
}