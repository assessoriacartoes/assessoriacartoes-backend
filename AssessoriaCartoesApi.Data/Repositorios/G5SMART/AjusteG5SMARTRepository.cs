using AssessoriaCartoesApi.Data.DbContextAssessoria;
using AssessoriaCartoesApi.Data.Entities.G5SMART;
using AssessoriaCartoesApi.Data.Repositorios.Base;
using AssessoriaCartoesApi.Data.Repositorios.interfaces;

namespace AssessoriaCartoesApi.Data.Repositorios.G5SMART
{
    public class AjusteG5SMARTRepository : Repository<AjusteG5SMART>, IAjusteG5SMARTRepository
    {
        public AjusteG5SMARTRepository(DefaultDbContext context) : base(context)
        {
        }
    }
}