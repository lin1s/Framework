using Core.Base.Implementation;
using Core.Base.Interface;
using Entity.TestDbA;
using Repository.IRepository;

namespace Repository.Repository
{
    public class TestTableRepository : BaseRepository<TestTable>, ITestTableRepository
    {
        public TestTableRepository(IUnitOfWork unitWork) : base(unitWork)
        {
        }
    }
}
