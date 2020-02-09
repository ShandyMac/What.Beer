using Microsoft.Extensions.DependencyInjection;
using What.Beer.Data.DataStores;
using What.Beer.Data.DataStores.MongoDb;
using What.Beer.Data.Repositories;

namespace What.Beer.Data.IoC.ServiceCollection
{
    public static class DataRegistry
    {
        public static IServiceCollection AddDataServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IDataStore, MongoDataStore>();
            serviceCollection.AddSingleton<IBeerRepository, BeerRepository>();
            return serviceCollection;
        }
    }
}
