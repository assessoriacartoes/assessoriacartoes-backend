using AssessoriaCartoesApi.Data.DbContextAssessoria;
using AssessoriaCartoesApi.Data.Entities.G5SMART;
using AssessoriaCartoesApi.Data.Repositorios.Base;
using AssessoriaCartoesApi.Data.Repositorios.interfaces;

namespace AssessoriaCartoesApi.Data.Repositorios.G5SMART
{
    public class FinanceiroG5SMARTRepository : Repository<FinanceiroG5SMART>, IFinanceiroG5SMARTRepository
    {
        public FinanceiroG5SMARTRepository(DefaultDbContext context) : base(context)
        {
        }
    }
}