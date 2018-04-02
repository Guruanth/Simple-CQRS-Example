namespace SampleApp.Cqrs.Query
{
    // NOTE: We don't need this interface for the example
    //public interface IQueryAsync<TResult> : IQuery<Task<TResult>>
    //{
    //}

    public interface IQuery<TResult> : IQuery
    {
    }

    public interface IQuery
    {
    }
}