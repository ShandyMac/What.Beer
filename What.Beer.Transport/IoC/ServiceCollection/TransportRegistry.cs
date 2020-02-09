using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using What.Beer.Data.IoC.ServiceCollection;

namespace What.Beer.Transport.IoC.ServiceCollection
{
    /// <summary>
    /// The <see cref="TransportRegistry"/> class.
    /// </summary>
    public static class TransportRegistry
    {
        /// <summary>
        /// Add the transport based services to the container.
        /// </summary>
        /// <param name="serviceCollection">The container.</param>
        /// <returns>The populated <see cref="IServiceCollection"/></returns>
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
