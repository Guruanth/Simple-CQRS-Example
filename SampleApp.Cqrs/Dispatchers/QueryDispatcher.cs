using Microsoft.Extensions.Logging;
using SampleApp.Cqrs.Query;
using SampleApp.Cqrs.QueryHandler;
using SampleApp.Cqrs.QueryHandler.Companies;
using SampleApp.Cqrs.QueryHandler.People;
using SampleApp.Cqrs.QueryResult;
using SampleApp.Dal.Infrastructure;
using System;
using System.Collections.Generic;

namespace SampleApp.Cqrs.Dispatchers
{
    public class QueryDispatcher : IQueryDispatcher
    {
        private readonly SampleAppContext _context;
        private readonly ILogger<QueryDispatcher> _logger;

        public QueryDispatcher(SampleAppContext context, ILogger<QueryDispatcher> logger)
        {
            _context = context;
            _logger = logger;
        }

        public TResult Dispatch<TResult>(IQuery<TResult> query)
        {
            _logger.LogInformation("Query.Dispatch");
            return RunQuery(query);
        }

        private TResult RunQuery<TResult>(IQuery<TResult> query)
        {
            _logger.LogInformation("Query.RunQuery");

            var queryHandler = GetQueryHandler<TResult>();

            return queryHandler.RunQuery(query);
        }

        /// <summary>
        /// Ignore this. It's clearly the WORST possible thing to do. But it works for this example
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="_context"></param>
        /// <returns></returns>
        private IQueryHandler<TResult> GetQueryHandler<TResult>()
        {
            _logger.LogInformation("Query.GetQueryHandler");

            IQueryHandler<TResult> queryHandler;
            if (typeof(TResult) == typeof(PersonQueryResult))
            {
                queryHandler = (IQueryHandler<TResult>)new PersonByIdQueryHandler(_context, _logger);
            }
            else if (typeof(TResult) == typeof(List<PersonQueryResult>))
            {
                queryHandler = (IQueryHandler<TResult>)new AllPeopleQueryHandler(_context, _logger);
            }
            else if (typeof(TResult) == typeof(CompanyQueryResult))
            {
                queryHandler = (IQueryHandler<TResult>)new CompanyByIdQueryHandler(_context, _logger);
            }
            else if (typeof(TResult) == typeof(List<CompanyQueryResult>))
            {
                queryHandler = (IQueryHandler<TResult>)new AllCompaniesQueryHandler(_context, _logger);
            }
            else
            {
                throw new Exception("Invalid type.");
            }

            return queryHandler;
        }
    }
}