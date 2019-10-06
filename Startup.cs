using System;
using DotnetTabulatorFiltering.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DotnetTabulatorFiltering
{
    public class Startup
    {
        public Startup (IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices (IServiceCollection services)
        {

            services.AddDbContext<TabulatorContext> (
                options => options.UseInMemoryDatabase (databaseName: "TabulatorDatabase")
            );
            services.AddScoped<ITabulatorRepository, TabulatorRepository> ();

            services.AddMvc ().SetCompatibilityVersion (CompatibilityVersion.Version_2_2);
        }

        public void Configure (IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment ())
            {
                app.UseDeveloperExceptionPage ();
            }
            else
            {
                app.UseExceptionHandler ("/Home/Error");
            }

            app.UseCors (builder => builder
                .AllowAnyOrigin ()
                .AllowAnyMethod ()
                .AllowAnyHeader ()
                .AllowCredentials ());
            app.UseHttpsRedirection ();
            app.UseStaticFiles ();
            try
            {
                using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory> ()
                    .CreateScope ())
                {
                    serviceScope.ServiceProvider.GetService<TabulatorContext> ().EnsureSeedData ();
                }
            }
            catch (Exception e)
            {
                var msg = e.Message;
                var stacktrace = e.StackTrace;
            }

            app.UseMvc (routes =>
            {
                routes.MapRoute (
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}