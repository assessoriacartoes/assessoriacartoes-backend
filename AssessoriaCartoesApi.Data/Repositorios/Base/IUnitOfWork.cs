using System.Threading.Tasks;

namespace AssessoriaCartoesApi.Data.Repositorios.Base
{
    public interface IUnitOfWork
    {
        Task<bool> CommitAsync();
    }
}