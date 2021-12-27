using AssessoriaCartoesApi.Data.DbContextAssessoria;
using AssessoriaCartoesApi.Data.Entities.G5SMART;
using AssessoriaCartoesApi.Data.Repositorios.Base;
using AssessoriaCartoesApi.Data.Repositorios.interfaces;

namespace AssessoriaCartoesApi.Data.Repositorios.G5SMART
{
    public class VendaG5SMARTRepository : Repository<VendaG5SMART>, IVendaG5SMARTRepository
    {
        public VendaG5SMARTRepository(DefaultDbContext context) : base(context)
        {
        }
    }
}