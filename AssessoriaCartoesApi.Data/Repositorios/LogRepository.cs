using AssessoriaCartoesApi.Data.DbContextAssessoria;
using AssessoriaCartoesApi.Data.Entities;
using AssessoriaCartoesApi.Data.Repositorios.Base;
using AssessoriaCartoesApi.Data.Repositorios.interfaces;

namespace AssessoriaCartoesApi.Data.Repositorios
{
    public class LogRepository : Repository<LogNexxera>, ILogRepository
    {
        public LogRepository(DefaultDbContext context) : base(context)
        {
        }
    }
}