using AssessoriaCartoesApi.Data.IoC;
using AssessoriaCartoesApi.Data.Services;
using AssessoriaCartoesApi.Settings;
using Hangfire;
using MySqlConnector;
using HangfireBasicAuthenticationFilter;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Hangfire.MySql;
using Hangfire.MySql.Core;

namespace AssessoriaCartoesApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var appSettingsSection = Configuration.GetSection("AssessoriaSettings");
            services.Configure<AssessoriaSettings>(appSettingsSection);
            var appSettings = appSettingsSection.Get<AssessoriaSettings>();

            services.AddHangfire(x => x.UseStorage(new MySqlStorage(appSettings.ConnectionString)));

            services.RegisterContexts(appSettings);
            services.RegisterRepositories();
            services.RegisterServices();

            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "AssessoriaCartoesApi", Version = "v1" });
            });

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                               .AllowAnyHeader()
                               .AllowAnyMethod();
                    });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AssessoriaCartoesApi v1"));
            }

            app.UseHangfireDashboard("/hangfire", new DashboardOptions()
            {
                AppPath = null,
                DashboardTitle = "Hangfire Dashboard",
                Authorization = new[]{
                    new HangfireCustomBasicAuthenticationFilter{
                        User = Configuration.GetSection("AssessoriaSettings:UserName").Value,
                        Pass = Configuration.GetSection("AssessoriaSettings:Password").Value
                    }
                },
            });

            var options = new BackgroundJobServerOptions { WorkerCount = 1 };
            app.UseHangfireServer(options);

            RecurringJob.AddOrUpdate<NexxeraClient>(x => x.Execute(), "0 14 * * *");

            app.UseRouting();
            app.UseAuthorization();
            app.UseCors();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}