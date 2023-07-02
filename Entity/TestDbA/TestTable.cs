using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.TestDbA
{
    [Table("TestTable")]
    public class TestTable
    {
        public Guid Id { get; set; }

        public string Test1 { get; set; }

        public string Test2 { get; set; }
    }
}
