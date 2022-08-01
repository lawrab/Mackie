using SnailRacing.Mackie.Domain;

namespace SnailRacing.Mackie.Infrastructure
{
    internal class GenericRepository<TEntity> : IRepository<TEntity> 
        where TEntity : class
    {
        private readonly AppDbContext _context;

        public GenericRepository(AppDbContext context) => _context = context;
        public void Add(TEntity entity)
        {
            _context.Add(entity);
        }

        public async Task<TEntity?> GetByIdAsync(int id)
        {
            return await _context.FindAsync<TEntity>(id);
        }

        public void Update(TEntity entity)
        {
            _context.Attach(entity);
            _context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public IEnumerable<TEntity> FindAsync(Func<TEntity, bool> predicate)
        {
            return _context.Set<TEntity>().AsQueryable().Where(predicate).ToList();
        }
    }
}
