using SampleApp.Cqrs.QueryHandler.Companies;
using SampleApp.Cqrs.QueryHandler.People;
using SampleApp.Cqrs.QueryResult;
using SampleApp.Dal.Infrastructure;
using System;
using System.Collections.Generic;

namespace SampleApp.Cqrs.Query
{
    public class QueryDispatcher : IQueryDispatcher
    {
        public TResult Dispatch<TResult>(IQuery<TResult> query)
        {
            return RunQuery(query);
        }

        private TResult RunQuery<TResult>(IQuery<TResult> query)
        {
            var queryHandler = GetQueryHandler<TResult>();

            return queryHandler.RunQuery(query);
        }

        /// <summary>
        /// Ignore this. It's clearly the WORST possible thing to do. But it works for this example
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="ctx"></param>
        /// <returns></returns>
        private IQueryHandler<TResult> GetQueryHandler<TResult>()
        {
            var ctx = new DbContextQuery();
            IQueryHandler<TResult> queryHandler;
            if (typeof(TResult) == typeof(PersonQueryResult))
            {
                queryHandler = (IQueryHandler<TResult>)new PersonByIdQueryHandler(ctx);
            }
            else if (typeof(TResult) == typeof(List<PersonQueryResult>))
            {
                queryHandler = (IQueryHandler<TResult>)new AllPeopleQueryHandler(ctx);
            }
            else if (typeof(TResult) == typeof(CompanyQueryResult))
            {
                queryHandler = (IQueryHandler<TResult>)new CompanyByIdQueryHandler(ctx);
            }
            else if (typeof(TResult) == typeof(List<CompanyQueryResult>))
            {
                queryHandler = (IQueryHandler<TResult>)new AllCompaniesQueryHandler(ctx);
            }
            else
            {
                throw new Exception("Invalid type.");
            }

            return queryHandler;
        }
    }
}