using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace TimeServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var defaultUrls = new string[]{ "http://*:8080" };
            var urls = args.Length > 0 ? args : defaultUrls;
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseStartup<Startup>()
                .UseUrls(urls)
                .Build();

            host.Run();
        }
    }

    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRouting();
        }

        public void Configure(IApplicationBuilder app)
        {  
            var defaultRouteHandler = new RouteHandler(context =>
            {
                return context.Response.WriteAsync("Use GET /time to retrive current UTC time.");
            });
            var routeBuilder = new RouteBuilder(app, defaultRouteHandler);
            routeBuilder.MapRoute("default", "");
            routeBuilder.MapGet("time", context =>
            {
                return context.Response.WriteAsync(
                    DateTime.Now.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:sszzz"));
            });
            var routes = routeBuilder.Build();
            app.UseRouter(routes);
        }
    }
}