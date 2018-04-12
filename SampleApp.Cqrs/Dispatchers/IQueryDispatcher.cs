using SampleApp.Cqrs.Query;

namespace SampleApp.Cqrs.Dispatchers
{
    public interface IQueryDispatcher
    {
        /// <summary>
        /// Dispatches query a query to its respective handler
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="query"></param>
        /// <returns></returns>
        TResult Dispatch<TResult>(IQuery<TResult> query);

        // NOTE: Commenting since we don't need SendAsync for the example
        // Task<TResult> SendAsync<TResult>(IQueryAsync<TResult> query);
    }
}