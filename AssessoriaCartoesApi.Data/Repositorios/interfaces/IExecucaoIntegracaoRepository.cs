using AssessoriaCartoesApi.Data.Entities;
using AssessoriaCartoesApi.Data.Repositorios.Base;
using System;
using System.Threading.Tasks;

namespace AssessoriaCartoesApi.Data.Repositorios.interfaces
{
    public interface IExecucaoIntegracaoRepository : IRepository<ExecucaoIntegracao>
    {
        Task<bool> GetByDateExecucao(DateTime date);
    }
}