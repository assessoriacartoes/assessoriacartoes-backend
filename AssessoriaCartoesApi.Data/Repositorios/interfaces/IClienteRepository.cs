using AssessoriaCartoesApi.Data.Entities;
using AssessoriaCartoesApi.Data.Repositorios.Base;
using System.Threading.Tasks;

namespace AssessoriaCartoesApi.Data.Repositorios.interfaces
{
    public interface IClienteRepository : IRepository<Cliente>
    {
        Task<Cliente> GetByEmailSenha(string email, string senha);
    }
}