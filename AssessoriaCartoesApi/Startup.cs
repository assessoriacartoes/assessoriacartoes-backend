using AssessoriaCartoesApi.Data.IoC;
using AssessoriaCartoesApi.Data.Services;
using AssessoriaCartoesApi.Settings;
using Hangfire;
using Hangfire.PostgreSql;
using HangfireBasicAuthenticationFilter;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;

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

            services.AddHangfire(x => x.UsePostgreSqlStorage(appSettings.ConnectionString));

            services.RegisterContexts(appSettings);
            services.RegisterRepositories();
            services.RegisterServices();

            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "AssessoriaCartoesApi", Version = "v1" });
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
            
            app.UseHangfireServer();

            RecurringJob.AddOrUpdate<NexxeraClient>(x => x.Execute(), Cron.MinuteInterval(1));

            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}