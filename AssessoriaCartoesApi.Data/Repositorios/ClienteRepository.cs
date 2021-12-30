using AssessoriaCartoesApi.Data.DbContextAssessoria;
using AssessoriaCartoesApi.Data.Entities;
using AssessoriaCartoesApi.Data.Repositorios.Base;
using AssessoriaCartoesApi.Data.Repositorios.interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace AssessoriaCartoesApi.Data.Repositorios
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(DefaultDbContext context) : base(context)
        {
        }

        public async Task<Cliente> GetByEmailSenha(string email, string senha)
        {
            return await Query().FirstOrDefaultAsync(x => x.Email == email && x.Password == senha);
        }
    }
}