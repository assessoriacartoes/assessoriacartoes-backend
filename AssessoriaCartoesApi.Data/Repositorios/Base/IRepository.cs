using System.Collections.Generic;
using System.Threading.Tasks;

namespace AssessoriaCartoesApi.Data.Repositorios.Base
{
    public interface IRepository<T> where T : class
    {
        Task<T> CreateAsync(T entity);
        Task<T> GetByIdAsync(int id);
        Task UpdateAsync(T entity, int id);
        Task<List<T>> GetAllAsync();
        Task DeleteAsync(int id);
    }
}