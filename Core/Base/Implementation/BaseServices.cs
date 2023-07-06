using Core.Base.Interface;

namespace Core.Base.Implementation
{
    public class BaseServices<TEntity> : IBaseServices<TEntity> where TEntity : class, new()
    {
        public IBaseRepository<TEntity> _baseRepository;

        public BaseServices(IBaseRepository<TEntity> baseRepository)
        {
            _baseRepository = baseRepository;
        }
    }
}
