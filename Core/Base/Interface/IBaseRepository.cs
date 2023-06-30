using System.Linq.Expressions;

namespace Core.Base.Interface
{
    public interface IBaseRepository<TEntity> where TEntity : class, new()
    {
        bool Add(TEntity entity);

        bool Add(List<TEntity> entityList);

        Task<bool> AddAsync(TEntity entity);

        Task<bool> AddAsync(List<TEntity> entityList);

        bool Delete(TEntity entity);

        bool Delete(List<TEntity> entityList);

        bool Delete(Expression<Func<TEntity, bool>> where);
    }
}