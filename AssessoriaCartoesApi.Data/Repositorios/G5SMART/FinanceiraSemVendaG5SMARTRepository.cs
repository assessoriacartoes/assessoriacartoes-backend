using AssessoriaCartoesApi.Data.DbContextAssessoria;
using AssessoriaCartoesApi.Data.Entities.G5SMART;
using AssessoriaCartoesApi.Data.Repositorios.Base;
using AssessoriaCartoesApi.Data.Repositorios.interfaces;

namespace AssessoriaCartoesApi.Data.Repositorios.G5SMART
{
    public class FinanceiraSemVendaG5SMARTRepository : Repository<FinanceiraSemVendaG5SMART>, IFinanceiraSemVendaG5SMARTRepository
    {
        public FinanceiraSemVendaG5SMARTRepository(DefaultDbContext context) : base(context)
        {
        }
    }
}