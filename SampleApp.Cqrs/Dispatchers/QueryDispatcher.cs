using Microsoft.Extensions.DependencyInjection;
using SampleApp.Cqrs.Query;
using SampleApp.Cqrs.QueryHandler;
using SampleApp.Dal.Infrastructure;
using System;

namespace SampleApp.Cqrs.Dispatchers
{
    public class QueryDispatcher : IQueryDispatcher
    {
        private readonly SampleAppContext _context;
        private readonly IServiceProvider _serviceProvider;

        public QueryDispatcher(SampleAppContext context, IServiceProvider serviceProvider)
        {
            _context = context;
            _serviceProvider = serviceProvider;
        }

        public TResult Dispatch<TResult>(IQuery<TResult> query)
        {
            return RunQuery(query);
        }

        private TResult RunQuery<TResult>(IQuery<TResult> query)
        {
            var queryHandler = _serviceProvider.GetService<IQueryHandler<TResult>>();

            if (queryHandler == null)
            {
                throw new ArgumentException("Handler not registered for type " + typeof(TResult).Name);
            }

            return queryHandler.RunQuery(query);
        }
    }
}