using Business.DataAccess.Contexts;
using Business.DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Text;

namespace MVC.Controllers
{
    public class DbController : Controller
    {
        private readonly Db _db;

        public DbController(Db db)
        {
            _db = db;
        }

        public IActionResult Seed()
        {
            var products = _db.Products.ToList();
            _db.Products.RemoveRange(products);

            var categories = _db.Categories.ToList();
            _db.Categories.RemoveRange(categories);

            var stores = _db.Stores.ToList();
            _db.Stores.RemoveRange(stores);

            _db.Categories.Add(new Category()
            {
                Name = "Computer",
                Description = "Laptops, Desktops and computer peripherals",
                Products = new List<Product>()
                {
                    new Product()
                    {
                        Name = "Laptop",
                        UnitPrice = 3000.5,
                        ExpirationDate = new DateTime(2032, 1, 27),
                        StockAmount = 10
                    },
                    new Product()
                    {
                        Name = "Mouse",
                        UnitPrice = 20.5,
                        StockAmount = 50,
                        Description = "Computer peripheral"
                    },
                    new Product()
                    {
                        Name = "Keyboard",
                        UnitPrice = 40,
                        StockAmount = 45,
                        Description = "Computer peripheral"
                    },
                    new Product()
                    {
                        Name = "Monitor",
                        UnitPrice = 2500,
                        ExpirationDate = DateTime.Parse("05/19/2027", new CultureInfo("en-US")),
                        StockAmount = 20,
                        Description = "Computer peripheral"
                    }
                }
            });

            _db.Categories.Add(new Category()
            {
                Name = "Home Theater System",
                Products = new List<Product>()
                {
                    new Product()
                    {
                        Name = "Speaker",
                        UnitPrice = 2500,
                        StockAmount = 70
                    },
                    new Product()
                    {
                        Name = "Receiver",
                        UnitPrice = 5000,
                        StockAmount = 30,
                        Description = "Home theater system component"
                    },
                    new Product()
                    {
                        Name = "Equalizer",
                        UnitPrice = 1000,
                        StockAmount = 40
                    }
                }
            });

            _db.Stores.Add(new Store()
            {
                Name = "Trendyol",
                IsVirtual = true
            });

            _db.Stores.Add(new Store()
            {
                Name = "MediaMarkt",
                IsVirtual = false
            });

            _db.SaveChanges();

            //return Content("Database seed successful.");
            return Content("<label style=\"color:red;\"><b>Database seed successful.</b></label>", "text/html", Encoding.UTF8);
            // Yeni bir view oluşturup işlem sonucunu göstermek yerine Controller base class'ının Content methodunu kullanıp işlem sonucunun boş bir sayfada gösterilmesini sağladık.
            // *1: Metinsel verinin düz yazı (plain text) olarak sayfada gösterilmesini sağlar.
            // *2: HTML verisinin sayfada HTML içerik olarak gösterilmesini sağlar.
            // *3: HTML verisinin sayfada Türkçe karakterleri destekleyen UTF8 karakter kümesi üzerinden HTML içerik olarak gösterilmesini sağlar.
        }
    }
}
