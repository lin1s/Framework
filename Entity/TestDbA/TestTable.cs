using System.ComponentModel.DataAnnotations.Schema;

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
