using System.Collections.Generic;

namespace SampleApp.Dal.Infrastructure
{
    public interface IDbContextQuery
    {
        /// <summary>
        /// Returning IEnumerable since it's just an example; Normally we should return IQueryable
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns></returns>
        IEnumerable<TEntity> GetQuery<TEntity>() where TEntity : class;
    }
}