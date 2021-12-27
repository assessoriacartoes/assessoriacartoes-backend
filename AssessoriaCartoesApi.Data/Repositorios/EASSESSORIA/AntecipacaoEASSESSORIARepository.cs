using AssessoriaCartoesApi.Data.DbContextAssessoria;
using AssessoriaCartoesApi.Data.Entities.EASSESSORIA;
using AssessoriaCartoesApi.Data.Repositorios.Base;
using AssessoriaCartoesApi.Data.Repositorios.interfaces;

namespace AssessoriaCartoesApi.Data.Repositorios.EASSESSORIA
{
    public class AntecipacaoEASSESSORIARepository : Repository<AntecipacaoEASSESSORIA>, IAntecipacaoEASSESSORIARepository
    {
        public AntecipacaoEASSESSORIARepository(DefaultDbContext context) : base(context)
        {
        }
    }
}