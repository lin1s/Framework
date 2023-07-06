using Core.Base.Interface;
using Core.Base.Interface.Auto_registration;
using Entity.TestDbA;

namespace Service.IServices
{
    public interface ITestTableServices : IBaseServices<TestTable>, IScopedInterface
    {
        string testa();
    }
}
