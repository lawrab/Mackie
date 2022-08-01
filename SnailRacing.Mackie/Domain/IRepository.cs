namespace SnailRacing.Mackie.Domain
{
    internal interface IRepository<TEntity>
    {
        Task<TEntity> GetByIdAsync(int id);
        void Add(TEntity entity);
        void Update(TEntity entity);
        Task SaveAsync();
    }
}
