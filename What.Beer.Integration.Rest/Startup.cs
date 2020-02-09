using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using What.Beer.Integration.Rest.IoC.ServiceCollection;
using What.Beer.Transport.IoC.ServiceCollection;

namespace What.Beer.Integration.Rest
{
    /// <summary>
    /// The <see cref="Startup"/> class.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Initializes a new instance of <see cref="Startup"/>
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Gets the configuration.
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// Configure the services.
        /// </summary>
        /// <param name="services">The services</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransportServices();
            services.AddRestServices();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(swagger => swagger.SwaggerEndpoint("/swagger/v1/swagger.json", "What Beer API"));
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
