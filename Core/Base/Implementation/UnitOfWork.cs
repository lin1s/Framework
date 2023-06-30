using Core.Base.DBContext;
using Core.Base.Interface;

namespace Core.Base.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public void BeginTransaction()
        {
            _context.Database.BeginTransaction();
        }

        public void CommitTransaction()
        {
            try
            {
                _context.Database.CommitTransaction();
            }
            catch (Exception ex)
            {
                _context.Database.RollbackTransaction();
            }
        }

        public void RollBackTransaction()
        {
            _context.Database.RollbackTransaction();
        }

    }
}