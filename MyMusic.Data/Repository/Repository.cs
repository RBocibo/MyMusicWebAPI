using Microsoft.EntityFrameworkCore;
using MyMusic.Core.Interfaces;
using MyMusic.Data.DataContext;
using System.Linq.Expressions;

namespace MyMusic.Data.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DbSet<TEntity> _dbSet;

        public Repository(MyMusicDbContext dbContext)
        {
            _dbSet = dbContext.Set<TEntity>();
        }
        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            return entity;
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await _dbSet.AddRangeAsync(entities);
        }

        public async void DeleteAsync(Expression<Func<TEntity, bool>> expression)
        {
            var response = await _dbSet.Where(expression).ToListAsync();
            if (response == null)
            {
                return;
            }

            _dbSet.RemoveRange(response);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            var response = await _dbSet.ToListAsync();

            return response;
        }

        public async Task<TEntity> GetByExpression(Expression<Func<TEntity, bool>> expression)
        {
            var entity = await _dbSet.FirstOrDefaultAsync(expression);
            return entity;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            _dbSet.Update(entity);
            return await Task.FromResult(entity);
        }
    }
}
