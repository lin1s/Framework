using Core.Base.Implementation;
using Core.Base.Interface;
using Entity.TestDbA;
using Service.IServices;

namespace Service.Services
{
    public class TestTableServices : BaseServices<TestTable>, ITestTableServices
    {
        private readonly IBaseRepository<TestTable> _baseRepository;

        public TestTableServices(IBaseRepository<TestTable> baseRepository) : base(baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public string testa()
        {
            var a = _baseRepository.Select(x => true);
            return "";
        }
    }
}
