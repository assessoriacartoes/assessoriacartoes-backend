using AssessoriaCartoesApi.Data.DbContextAssessoria;
using AssessoriaCartoesApi.Data.Entities.G5SMART;
using AssessoriaCartoesApi.Data.Repositorios.Base;
using AssessoriaCartoesApi.Data.Repositorios.interfaces;

namespace AssessoriaCartoesApi.Data.Repositorios.G5SMART
{
    public class TransacaoG5SMARTRepository : Repository<TransacaoG5SMART>, ITransacaoG5SMARTRepository
    {
        public TransacaoG5SMARTRepository(DefaultDbContext context) : base(context)
        {
        }
    }
}