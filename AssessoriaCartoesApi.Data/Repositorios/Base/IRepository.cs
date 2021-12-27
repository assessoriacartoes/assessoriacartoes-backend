using System.Threading.Tasks;

namespace AssessoriaCartoesApi.Data.Repositorios.Base
{
    public interface IRepository<T> where T : class
    {
        Task<T> CreateAsync(T entity);
    }
}