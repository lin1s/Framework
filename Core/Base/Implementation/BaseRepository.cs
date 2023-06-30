using Core.Base.DBContext;
using Core.Base.Interface;

namespace Core.Base.Implementation
{
    public class BaseRepository<TEntity> : IBaseRepository where TEntity : class, new()
    {
        private readonly IUnitOfWork _unitWork;
        private readonly ApplicationDbContext _context;

        public BaseRepository(IUnitOfWork unitWork)
        {
            _unitWork = unitWork;
        }

        public bool Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            int count = _context.SaveChanges();
            return count == 1 ? true : false;
        }

        public bool Add(List<TEntity> entityList)
        {
            _context.Set<TEntity>().AddRange(entityList);
            int count = _context.SaveChanges();
            return count == entityList.Count ? true : false;
        }
    }
}