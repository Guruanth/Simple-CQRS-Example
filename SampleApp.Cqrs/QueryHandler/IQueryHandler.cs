using SampleApp.Cqrs.Query;

namespace SampleApp.Cqrs.QueryHandler
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