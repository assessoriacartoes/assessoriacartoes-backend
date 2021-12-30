using AssessoriaCartoesApi.Data.Repositorios;
using AssessoriaCartoesApi.Data.Repositorios.Base;
using AssessoriaCartoesApi.Data.Repositorios.EASSESSORIA;
using AssessoriaCartoesApi.Data.Repositorios.G5SMART;
using AssessoriaCartoesApi.Data.Repositorios.interfaces;
using Bynem.Data.Repositories.Base;
using Microsoft.Extensions.DependencyInjection;

namespace AssessoriaCartoesApi.Data.IoC
{
    public static class RepositoryExtension
    {
        public static IServiceCollection RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<IAjusteEASSESSORIARepository, AjusteEASSESSORIARepository>();
            services.AddScoped<IAntecipacaoEASSESSORIARepository, AntecipacaoEASSESSORIARepository>();
            services.AddScoped<IFinanceiraSemVendaEASSESSORIARepository, FinanceiraSemVendaEASSESSORIARepository>();
            services.AddScoped<IFinanceiroEASSESSORIARepository, FinanceiroEASSESSORIARepository>();
            services.AddScoped<ITransacaoEASSESSORIARepository, TransacaoEASSESSORIARepository>();
            services.AddScoped<IVendaEASSESSORIARepository, VendaEASSESSORIARepository>();

            services.AddScoped<IAjusteG5SMARTRepository, AjusteG5SMARTRepository>();
            services.AddScoped<IAntecipacaoG5SMARTRepository, AntecipacaoG5SMARTRepository>();
            services.AddScoped<IFinanceiraSemVendaG5SMARTRepository, FinanceiraSemVendaG5SMARTRepository>();
            services.AddScoped<IFinanceiroG5SMARTRepository, FinanceiroG5SMARTRepository>();
            services.AddScoped<ITransacaoG5SMARTRepository, TransacaoG5SMARTRepository>();
            services.AddScoped<IVendaG5SMARTRepository, VendaG5SMARTRepository>();
            
            services.AddScoped<ILogRepository, LogRepository>();
            services.AddScoped<IExecucaoIntegracaoRepository, ExecucaoIntegracaoRepository>();
            services.AddScoped<IClienteRepository, ClienteRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}