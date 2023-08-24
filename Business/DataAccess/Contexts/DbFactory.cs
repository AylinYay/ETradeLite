using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Business.DataAccess.Contexts
{
    // Db objesini oluþturup kullanýlmasýný saðlayan fabrika class'ý,
    // scaffolding iþlemleri için bu class oluþturulmalýdýr.

    public class DbFactory : IDesignTimeDbContextFactory<Db>
    {
        public Db CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<Db>();
            optionsBuilder.UseSqlServer("server=.\\SQLAYLIN;database=ETradeDB;user id=sa;password=sa;multipleactiveresultsets=true;trustservercertificate=true;");
            return new Db(optionsBuilder.Options);
        }
    }
}
