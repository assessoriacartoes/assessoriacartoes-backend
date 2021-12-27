using AssessoriaCartoesApi.Data.DbContextAssessoria;
using AssessoriaCartoesApi.Data.Entities.G5SMART;
using AssessoriaCartoesApi.Data.Repositorios.Base;
using AssessoriaCartoesApi.Data.Repositorios.interfaces;

namespace AssessoriaCartoesApi.Data.Repositorios.G5SMART
{
    public class AntecipacaoG5SMARTRepository : Repository<AntecipacaoG5SMART>, IAntecipacaoG5SMARTRepository
    {
        public AntecipacaoG5SMARTRepository(DefaultDbContext context) : base(context)
        {
        }
    }
}