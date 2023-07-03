using Core.Base.Interface;
using Core.Base.Interface.Auto_registration;
using Entity.TestDbA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IServices
{
    public interface ITestTableServices: IScopedInterface
    {
        string testa();
    }
}
