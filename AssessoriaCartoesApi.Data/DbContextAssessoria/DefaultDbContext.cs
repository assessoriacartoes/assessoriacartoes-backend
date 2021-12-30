using AssessoriaCartoesApi.Data.Entities;
using AssessoriaCartoesApi.Data.Entities.EASSESSORIA;
using AssessoriaCartoesApi.Data.Entities.G5SMART;
using Microsoft.EntityFrameworkCore;

namespace AssessoriaCartoesApi.Data.DbContextAssessoria
{
    public class DefaultDbContext : DbContext
    {
        public DefaultDbContext(DbContextOptions<DefaultDbContext> options) : base(options) { }

        public DbSet<AjusteEASSESSORIA> AjusteEASSESSORIA { get; set; }
        public DbSet<AntecipacaoEASSESSORIA> AntecipacaoEASSESSORIA { get; set; }
        public DbSet<FinanceiraSemVendaEASSESSORIA> FinanceiraSemVendaEASSESSORIA { get; set; }
        public DbSet<FinanceiroEASSESSORIA> FinanceiroEASSESSORIA { get; set; }
        public DbSet<TransacaoEASSESSORIA> TransacaoEASSESSORIA { get; set; }
        public DbSet<VendaEASSESSORIA> VendaEASSESSORIA { get; set; }

        public DbSet<AjusteG5SMART> AjusteG5SMART { get; set; }
        public DbSet<AntecipacaoG5SMART> AntecipacaoG5SMART { get; set; }
        public DbSet<FinanceiraSemVendaG5SMART> FinanceiraSemVendaG5SMART { get; set; }
        public DbSet<FinanceiroG5SMART> FinanceiroG5SMART { get; set; }
        public DbSet<TransacaoG5SMART> TransacaoG5SMART { get; set; }
        public DbSet<VendaG5SMART> VendaG5SMART { get; set; }

        public DbSet<LogNexxera> LogsNexxera { get; set; }
        public DbSet<ExecucaoIntegracao> ExecucaoIntegracoes { get; set; }
        public DbSet<Cliente> Clientes { get; set; }


        public DbSet<T> GetDbSet<T>() where T : class => Set<T>();
        public bool HasChanges() => ChangeTracker.HasChanges();
    }
}