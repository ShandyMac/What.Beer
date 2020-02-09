using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using What.Beer.Common.Domain;

namespace What.Beer.Data.DataStores
{
    interface IDataStore
    {
        Task<T> Find<T>(Expression<Func<T, bool>> filter) where T : DomainObject;
        Task Save<T>(T domainObject) where T : DomainObject;
    }
}
