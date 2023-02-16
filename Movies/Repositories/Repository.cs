using Microsoft.EntityFrameworkCore;
using Movies.Data;
using System.Linq.Expressions;

namespace Movies.Repositories;

public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
{
    private readonly MovieDbContext _movieDbContext;
    private readonly DbSet<TEntity> _dbSet;

    public Repository(MovieDbContext movieDbContext)
    {
        _movieDbContext = movieDbContext;
        _dbSet = movieDbContext.Set<TEntity>();
    }

    public virtual async Task AddEntity(TEntity entity)
    {
        await _dbSet.AddAsync(entity);
    }

    public virtual async Task DeleteEntity(Expression<Func<TEntity, bool>> expression)
    {
        var entity = await _dbSet.FirstOrDefaultAsync(expression);

        if(entity is not null)
        {
            _dbSet.Remove(entity);
        }
    }

    public virtual IEnumerable<TEntity> GetEntities()
    {
        return _dbSet.AsNoTracking();
    }

    public virtual async Task<TEntity?> GetOneEntity(Expression<Func<TEntity, bool>> expression)
    {
        return await _dbSet.FirstOrDefaultAsync(expression);
    }

    public virtual Task UpdateEntity(TEntity entity)
    {
        _dbSet.Entry(entity).State = EntityState.Modified;

        return Task.CompletedTask;
    }

    public virtual async Task SaveChanges()
    {
        await _movieDbContext.SaveChangesAsync();
    }
}
