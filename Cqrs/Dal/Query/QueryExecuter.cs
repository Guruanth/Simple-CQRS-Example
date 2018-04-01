using Cqrs.Contracts;
using Cqrs.Dal.Infrastructure;
using Cqrs.Dal.Query.Api;
using Cqrs.Dal.Query.Companies;
using Cqrs.Dal.Query.People;
using System;
using System.Collections.Generic;

namespace Cqrs.Dal.Query
{
    public class QueryRunner : IQueryRunner
    {
        public TResult Send<TResult>(IQuery<TResult> query)
        {
            return RunQuery(query);
        }

        private TResult RunQuery<TResult>(IQuery<TResult> query)
        {
            IQueryHandler<TResult> queryHandler = GetQueryHandler<TResult>();

            return queryHandler.RunQuery(query);
        }

        /// <summary>
        /// Ignore this. It's clearly the WORST possible thing to do. But it works for this example
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="ctx"></param>
        /// <returns></returns>
        private static IQueryHandler<TResult> GetQueryHandler<TResult>()
        {
            var ctx = new DbContextQuery();
            IQueryHandler<TResult> queryHandler;
            if (typeof(TResult) == typeof(PersonResponse))
            {
                queryHandler = (IQueryHandler<TResult>)new SinglePersonResponseQueryHandler(ctx);
            }
            else if (typeof(TResult) == typeof(List<PersonResponse>))
            {
                queryHandler = (IQueryHandler<TResult>)new PeopleResponseQueryHandler(ctx);
            }
            else if (typeof(TResult) == typeof(CompanyResponse))
            {
                queryHandler = (IQueryHandler<TResult>)new SingleCompanyResponseQueryHandler(ctx);
            }
            else if (typeof(TResult) == typeof(List<CompanyResponse>))
            {
                queryHandler = (IQueryHandler<TResult>)new CompaniesResponseQueryHandler(ctx);
            }
            else
            {
                throw new Exception("Invalid type.");
            }

            return queryHandler;
        }
    }
}