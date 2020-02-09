using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using What.Beer.Data.IoC.ServiceCollection;

namespace What.Beer.Transport.IoC.ServiceCollection
{
    public static class TransportRegistry
    {
        public static IServiceCollection AddTransportServices(this IServiceCollection serviceCollection)
        {
            var assemblies = new[] 
            {
                Assembly.GetCallingAssembly(),
                Assembly.GetExecutingAssembly(),
                typeof(DataRegistry).Assembly 
            };

            serviceCollection.AddMediatR(assemblies);
            serviceCollection.AddDataServices();
            serviceCollection.AddSingleton<IMessageBus, MessageBus>();
            return serviceCollection;
        }
    }
}
