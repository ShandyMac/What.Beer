using Microsoft.Extensions.DependencyInjection;
using What.Beer.Data.DataStores;
using What.Beer.Data.DataStores.MongoDb;
using What.Beer.Data.Repositories;

namespace What.Beer.Data.IoC.ServiceCollection
{
    /// <summary>
    /// The <see cref="DataRegistry"/> class.
    /// </summary>
    public static class DataRegistry
    {
        /// <summary>
        /// Register the data services.
        /// </summary>
        /// <param name="serviceCollection">The service collection.</param>
        /// <returns>The populated <see cref="IServiceCollection"/></returns>
        public static IServiceCollection AddDataServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IDataStore, MongoDataStore>();
            serviceCollection.AddSingleton<IBeerRepository, BeerRepository>();
            return serviceCollection;
        }
    }
}
