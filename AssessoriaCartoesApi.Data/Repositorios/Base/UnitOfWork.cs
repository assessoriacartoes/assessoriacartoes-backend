using AssessoriaCartoesApi.Data.DbContextAssessoria;
using AssessoriaCartoesApi.Data.Repositorios.Base;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Bynem.Data.Repositories.Base
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DefaultDbContext _context;

        public UnitOfWork(DefaultDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CommitAsync()
        {
            var commited = true;
            if (!_context.HasChanges())
                return false;

            var strategy = _context.Database.CreateExecutionStrategy();
            await strategy.ExecuteAsync(async () =>
            {
                await using var dbContextTransaction = await _context.Database.BeginTransactionAsync();
                try
                {
                    await _context.SaveChangesAsync();
                    await dbContextTransaction.CommitAsync();
                }
                catch
                {
                    await dbContextTransaction.RollbackAsync();
                    commited = false;
                }
            });

            return commited;
        }
    }
}