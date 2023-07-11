using Core.Base.Implementation;
using Core.Base.Interface;
using Entity.TestDbA;
using Service.IServices;
using System.Linq.Expressions;
using static Core.Extension.FileName;

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
            var expressions = Expressionable.Create<TestTable>().AndIF(true, x => true).ToExpression();
            var a = _baseRepository.Select(expressions);

            return "";
        }
    }
}
