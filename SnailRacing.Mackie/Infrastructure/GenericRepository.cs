using SnailRacing.Mackie.Domain;

namespace SnailRacing.Mackie.Infrastructure
{
    internal class GenericRepository<TEntity> where TEntity : class, IRepository<TEntity>
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

        public Task SaveAsync()
        {
            return _context.SaveChangesAsync();
        }

        public void Update(TEntity entity)
        {
            _context.Attach(entity);
            _context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }
    }
}
