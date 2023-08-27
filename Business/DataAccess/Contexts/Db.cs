using Business.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Business.DataAccess.Contexts
{
    public class Db : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Store> Stores { get; set; }

        public Db(DbContextOptions options) : base(options)
        {        
        }
    }
}



//string connectionString = "server=AYLIN\SQLAYLIN;database=ETradeDB;trusted_connection=true;multipleactiveresultsets=true;trustservercertificate=true;";