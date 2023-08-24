using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Business.DataAccess.Contexts
{
    // Db objesini olu�turup kullan�lmas�n� sa�layan fabrika class'�,
    // scaffolding i�lemleri i�in bu class olu�turulmal�d�r.

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
