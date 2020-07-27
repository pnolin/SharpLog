using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SharpLog.Gateway.WebAPI.Models.Constants;
using System;

namespace SharpLog.Orchestrator.WebAPI
{
    public class Startup
    {
        private readonly string _myAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(_myAllowSpecificOrigins, builder =>
                {
                    builder.WithOrigins(Configuration["FrontEndOrigin"]);
                    builder.WithHeaders("authorization");
                    builder.WithHeaders("Content-Type");
                    builder.AllowAnyMethod();
                });
            });

            services.AddControllers();
            services.AddHttpClient(Clients.Security, client =>
            {
                client.BaseAddress = new Uri(Configuration["Routes:Security"]);
            });

            services.AddHttpClient(Clients.Users, client =>
            {
                client.BaseAddress = new Uri(Configuration["Routes:Users"]);
            });

            services.AddHttpClient(Clients.Backlog, client =>
            {
                client.BaseAddress = new Uri(Configuration["Routes:Backlog"]);
            });

            services.AddHttpClient(Clients.IGDB, client =>
            {
                client.BaseAddress = new Uri(Configuration["Routes:IGDB"]);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(_myAllowSpecificOrigins);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}