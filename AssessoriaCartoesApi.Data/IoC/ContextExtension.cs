using AssessoriaCartoesApi.Data.DbContextAssessoria;
using AssessoriaCartoesApi.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AssessoriaCartoesApi.Data.IoC
{
    public static class ContextExtension
    {
        public static IServiceCollection RegisterContexts(this IServiceCollection services, AssessoriaSettings appSettings)
        {
            services.AddDbContext<DefaultDbContext>(options => options.UseNpgsql(appSettings.ConnectionString,
                x => x.MigrationsAssembly("AssessoriaCartoesApi.Data")));

            return services;
        }
    }
}