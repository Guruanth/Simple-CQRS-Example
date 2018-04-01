using Cqrs.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cqrs.Dal.Query.Api
{
    public interface IQueryRunner
    {
        TResult Send<TResult>(IQuery<TResult> query);

        // NOTE: Commenting since we don't need SendAsync for the example
        // Task<TResult> SendAsync<TResult>(IQueryAsync<TResult> query);
    }
}