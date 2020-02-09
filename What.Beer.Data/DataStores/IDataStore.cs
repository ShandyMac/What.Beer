using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using What.Beer.Common.Domain;

namespace What.Beer.Data.DataStores
{
    /// <summary>
    /// The <see cref="IDataStore"/> interface.
    /// </summary>
    interface IDataStore
    {
        /// <summary>
        /// Find a <see cref="DomainObject"/> from the data store.
        /// </summary>
        /// <typeparam name="T">The type to find.</typeparam>
        /// <param name="filter">The filter.</param>
        /// <returns>The <see cref="DomainObject"/></returns>
        Task<T> Find<T>(Expression<Func<T, bool>> filter) where T : DomainObject;

        /// <summary>
        /// Save a <see cref="DomainObject"/> to the data store.
        /// </summary>
        /// <typeparam name="T">The type.</typeparam>
        /// <param name="domainObject">The domain object.</param>
        /// <returns>The <see cref="Task"/></returns>
        Task Save<T>(T domainObject) where T : DomainObject;
    }
}
