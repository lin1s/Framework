using Core.Base.DBContext;
using Core.Base.Interface;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Core.Base.Implementation
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class, new()
    {
        private readonly IUnitOfWork _unitWork;
        private readonly ApplicationDbContext _context;

        public BaseRepository(IUnitOfWork unitWork)
        {
            _unitWork = unitWork;

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-LJ93NP5\\SQLEXPRESS;Initial Catalog=TestDb;User ID=sa;Password=sa;TrustServerCertificate=true");

            _context = new ApplicationDbContext(optionsBuilder.Options);

        }

        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            int count = _context.SaveChanges();
            return count == 1 ? true : false;
        }

        /// <summary>
        /// 批量添加数据
        /// </summary>
        /// <param name="entityList"></param>
        /// <returns></returns>
        public bool Add(List<TEntity> entityList)
        {
            try
            {
                _unitWork.BeginTransaction();
                _context.Set<TEntity>().AddRange(entityList);
                int count = _context.SaveChanges();
                bool result = count == entityList.Count ? true : false;
                _unitWork.CommitTransaction();
                return result;
            }
            catch (Exception ex)
            {
                _unitWork.RollBackTransaction();
                return false;
            }
        }

        /// <summary>
        /// 异步添加数据
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<bool> AddAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
            int count = await _context.SaveChangesAsync();
            return count == 1 ? true : false;
        }

        /// <summary>
        /// 异步批量添加数据
        /// </summary>
        /// <param name="entityList"></param>
        /// <returns></returns>
        public async Task<bool> AddAsync(List<TEntity> entityList)
        {
            try
            {
                _unitWork.BeginTransaction();
                await _context.Set<TEntity>().AddRangeAsync(entityList);
                int count = await _context.SaveChangesAsync();
                bool result = count == entityList.Count ? true : false;
                _unitWork.CommitTransaction();
                return result;
            }
            catch (Exception ex)
            {
                _unitWork.RollBackTransaction();
                return false;
            }
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            int count = _context.SaveChanges();
            return count == 1 ? true : false;
        }

        /// <summary>
        /// 批量删除数据
        /// </summary>
        /// <param name="entityList"></param>
        /// <returns></returns>
        public bool Delete(List<TEntity> entityList)
        {
            _unitWork.BeginTransaction();
            _context.Set<TEntity>().RemoveRange(entityList);
            int count = _context.SaveChanges();
            bool result = count == entityList.Count ? true : false;
            _unitWork.CommitTransaction();
            return result;
        }

        /// <summary>
        /// 根据条件删除数据
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public bool Delete(Expression<Func<TEntity, bool>> where)
        {
            List<TEntity> entityList = _context.Set<TEntity>().Where(where).ToList();
            return this.Delete(entityList);
        }

        /// <summary>
        /// 修改数据
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
            int count = _context.SaveChanges();
            return count == 1 ? true : false;
        }

        /// <summary>
        /// 批量修改数据
        /// </summary>
        /// <param name="entityList"></param>
        /// <returns></returns>
        public bool Update(List<TEntity> entityList)
        {
            try
            {
                _unitWork.BeginTransaction();
                _context.Set<TEntity>().UpdateRange(entityList);
                int count = _context.SaveChanges();
                bool result = count == entityList.Count ? true : false;
                _unitWork.CommitTransaction();
                return result;
            }
            catch (Exception ex)
            {
                _unitWork.RollBackTransaction();
                return false;
            }
        }

        public TEntity Find(Expression<Func<TEntity, bool>> where)
        {
            return _context.Set<TEntity>().First(where);
        }

        public async Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> where)
        {
            return await _context.Set<TEntity>().FirstAsync(where);
        }

        public List<TEntity> Select(Expression<Func<TEntity, bool>> where)
        {
            return _context.Set<TEntity>().Where(where).ToList();
        }

        public async Task<List<TEntity>> SelectAsync(Expression<Func<TEntity, bool>> where)
        {
            return await _context.Set<TEntity>().Where(where).ToListAsync();
        }

        public List<TEntity> GetPageList(Expression<Func<TEntity, bool>> where, int pageNumber, int pageSize)
        {
            return _context.Set<TEntity>().Where(where).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
        }

        public async Task<List<TEntity>> GetPageListAsync(Expression<Func<TEntity, bool>> where, int pageNumber, int pageSize)
        {
            return await _context.Set<TEntity>().Where(where).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
        }

    }
}