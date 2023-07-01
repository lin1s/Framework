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

        bool Update(TEntity entity);

        bool Update(List<TEntity> entityList);

        TEntity Find(Expression<Func<TEntity, bool>> where);

        Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> where);

        List<TEntity> Select(Expression<Func<TEntity, bool>> where);

        Task<List<TEntity>> SelectAsync(Expression<Func<TEntity, bool>> where);

        List<TEntity> GetPageList(Expression<Func<TEntity, bool>> where, int pageNumber, int pageSize);

        Task<List<TEntity>> GetPageListAsync(Expression<Func<TEntity, bool>> where, int pageNumber, int pageSize);
    }
}