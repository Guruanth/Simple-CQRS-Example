﻿namespace Cqrs.Dal.Query.Api
{
    public interface IQueryDispatcher
    {
        TResult Dispatch<TResult>(IQuery<TResult> query);

        // NOTE: Commenting since we don't need SendAsync for the example
        // Task<TResult> SendAsync<TResult>(IQueryAsync<TResult> query);
    }
}