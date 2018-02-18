using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging; // Added loggerFactory for Error Feedback (meant for use only during development)

namespace MVC
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSession(); // including Session as a service
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory) // Added loggerFactory for Error Feedback
        {
            loggerFactory.AddConsole();
                if (env.IsDevelopment())
                {
                app.UseDeveloperExceptionPage();
                }
            // Other middleware
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseSession(); // including Session as an app configuration
            app.UseMvc(); // Now that we've learned cleaner routing syntax (Controller.cs), we don't need clunky versions like below
            // app.UseMvc(routes =>
            // {
            //     routes.MapRoute(
            //         name: "Default", // The route's name is only for our own reference
            //         template: "", // The pattern that the route matches
            //         defaults: new {controller = "Home", action = "Index"} // The controller and method to execute
            //     );
            // });          
            // app.UseMvc(routes =>
            // {
            //     routes.MapRoute(
            //         name: "default",
            //         template: "{controller=Home}/{action=Index}/{id?}");
            // });
        }
    }
}
