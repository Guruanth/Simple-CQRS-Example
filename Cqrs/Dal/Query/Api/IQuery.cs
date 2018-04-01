using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cqrs.Dal.Query.Api
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