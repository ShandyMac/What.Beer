using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace What.Beer.Integration.Rest.IoC.ServiceCollection
{
    public static class RestRegistry
    {
        public static IServiceCollection AddRestServices(this IServiceCollection serviceCollection) 
        {
            serviceCollection.AddSwaggerGen(swagger => swagger.SwaggerDoc("v1", new OpenApiInfo { Title = "What Beer API", Version = "v1" }));
            serviceCollection.AddControllers();
            return serviceCollection;
        }
    }
}
