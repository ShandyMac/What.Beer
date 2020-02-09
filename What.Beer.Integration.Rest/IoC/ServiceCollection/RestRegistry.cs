using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace What.Beer.Integration.Rest.IoC.ServiceCollection
{
    /// <summary>
    /// The <see cref="RestRegistry"/> class.
    /// </summary>
    public static class RestRegistry
    {
        /// <summary>
        /// Add the rest services to the service collection.
        /// </summary>
        /// <param name="serviceCollection">The service collection.</param>
        /// <returns>The populated <see cref="IServiceCollection"/></returns>
        public static IServiceCollection AddRestServices(this IServiceCollection serviceCollection) 
        {
            serviceCollection.AddSwaggerGen(swagger => swagger.SwaggerDoc("v1", new OpenApiInfo { Title = "What Beer API", Version = "v1" }));
            serviceCollection.AddControllers();
            return serviceCollection;
        }
    }
}
