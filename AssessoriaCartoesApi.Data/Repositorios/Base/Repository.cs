using AssessoriaCartoesApi.Data.DbContextAssessoria;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssessoriaCartoesApi.Data.Repositorios.Base
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DefaultDbContext _context;

        protected Repository(DefaultDbContext context)
        {
            _context = context;
        }

        public virtual async Task<TEntity> CreateAsync(TEntity entity)
        {
            var entitySaved = (await _context.GetDbSet<TEntity>().AddAsync(entity)).Entity;
            return entitySaved;
        }

        public virtual async Task<TEntity> GetByIdAsync(int id)
          => await _context.GetDbSet<TEntity>().FindAsync(id);

        public virtual async Task UpdateAsync(TEntity entity, int id)
        {
            if (entity == null) return;
            var existing = await GetByIdAsync(id);

            if (existing != null)
                _context.Entry(existing).CurrentValues.SetValues(entity);
        }

        public async Task<List<TEntity>> GetAllAsync()
            => await _context.GetDbSet<TEntity>().ToListAsync();

        public virtual async Task DeleteAsync(int id)
        {
            var element = await GetByIdAsync(id);
            _context.Set<TEntity>().Remove(element);
        }

        protected virtual IQueryable<TEntity> Query()
            => _context.GetDbSet<TEntity>().AsNoTracking().AsQueryable();
    }
}