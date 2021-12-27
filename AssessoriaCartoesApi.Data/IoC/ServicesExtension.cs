using AssessoriaCartoesApi.Data.Services;
using AssessoriaCartoesApi.Services;
using Microsoft.Extensions.DependencyInjection;

namespace AssessoriaCartoesApi.Data.IoC
{
    public static class ServicesExtension
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<ILerCSVService, LerCSVService>();
            services.AddScoped<INexxeraClient, NexxeraClient>();

            return services;
        }
    }
}