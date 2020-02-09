using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace What.Beer.Integration.Rest
{
    /// <summary>
    /// The <see cref="Program"/> class.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// The entry point.
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// Create the host.
        /// </summary>
        /// <param name="args">The args.</param>
        /// <returns>The <see cref="IHostBuilder"/></returns>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
