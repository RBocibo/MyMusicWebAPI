using System.Linq.Expressions;

namespace MyMusic.Core.Interfaces
{
    public interface IRepository <TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByExpression(Expression<Func<TEntity, bool>> expression);
        Task<TEntity> AddAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        void DeleteAsync(Expression<Func<TEntity, bool>> expression);
        Task AddRangeAsync(IEnumerable<TEntity> entities);
    }
}
