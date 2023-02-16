using System.Linq.Expressions;

namespace Movies.Repositories;

public interface IRepository<TEntity> where TEntity : class
{
    Task AddEntity(TEntity entity);
    IEnumerable<TEntity> GetEntities();
    Task<TEntity?> GetOneEntity(Expression<Func<TEntity, bool>> expression);
    Task UpdateEntity(TEntity entity);
    Task DeleteEntity(Expression<Func<TEntity, bool>> expression);
    Task SaveChanges();
}
