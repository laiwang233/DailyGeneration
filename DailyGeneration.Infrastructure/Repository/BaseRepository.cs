using System.Linq.Expressions;
using DailyGeneration.Domain.Entities;
using DailyGeneration.Infrastructure.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DailyGeneration.Infrastructure.Repository
{
    public class BaseRepository<TEntity, TId> 
        where TEntity : BaseEntity<TId> 
        where TId : struct
    {
        private readonly TodoDbContext _todoDbContext;

        private readonly DbSet<TEntity> _dbSet;

        public BaseRepository(TodoDbContext todoDbContext)
        {
            _todoDbContext = todoDbContext ?? throw new ArgumentNullException(nameof(todoDbContext), "参数不可为空");
            _dbSet = _todoDbContext.Set<TEntity>();
        }

        public async Task<TEntity?> GetByIdAsync(TId id) => await _dbSet.AsNoTracking().FirstOrDefaultAsync(s => s.Id.Equals(id));

        public async Task<IEnumerable<TEntity>> GetAllAsync() => await _dbSet.AsNoTracking().ToListAsync();

        public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate) => await _dbSet.AsNoTracking().Where(predicate).ToListAsync();

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            var res = await _dbSet.AddAsync(entity);
            await _todoDbContext.SaveChangesAsync();
            return res.Entity;
        }

        public async Task<int> UpdateAsync(TEntity entity)
        {
            _dbSet.Update(entity);
            return await _todoDbContext.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(TEntity entity)
        {
            _dbSet.Remove(entity);
            return await _todoDbContext.SaveChangesAsync();
        }
    }
}