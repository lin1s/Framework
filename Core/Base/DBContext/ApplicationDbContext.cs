using Entity.TestDbA;
using Microsoft.EntityFrameworkCore;

namespace Core.Base.DBContext
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<TestTable> _testTable { get; set; }
    }
}
