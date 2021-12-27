using AssessoriaCartoesApi.Data.DbContextAssessoria;
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
    }
}