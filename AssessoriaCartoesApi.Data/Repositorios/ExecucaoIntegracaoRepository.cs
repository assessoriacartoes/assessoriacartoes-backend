using AssessoriaCartoesApi.Data.DbContextAssessoria;
using AssessoriaCartoesApi.Data.Entities;
using AssessoriaCartoesApi.Data.Repositorios.Base;
using AssessoriaCartoesApi.Data.Repositorios.interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace AssessoriaCartoesApi.Data.Repositorios
{
    public class ExecucaoIntegracaoRepository : Repository<ExecucaoIntegracao>, IExecucaoIntegracaoRepository
    {
        public ExecucaoIntegracaoRepository(DefaultDbContext context) : base(context)
        {
        }

        public async Task<bool> GetByDateExecucao(DateTime date)
        {
            return await Query().AnyAsync(x => x.DataExecucaoFinalizada.Date.Day == date.Date.Day);
        }
    }
}