using AppCore.Business.DataAccess.EntityFramework.Bases;
using Business.DataAccess.Contexts;
using Business.DataAccess.Entities;
using System.Globalization;
using System.Linq.Expressions;

namespace Business.DataAccess.Services
{
    public abstract class ProductServiceBase : Service<Product>
    {
        protected ProductServiceBase(Db db) : base(db)
        {
        }
    }

    public class ProductService : ProductServiceBase
    {
        public ProductService(Db db) : base(db)
        {
        }

        public override IQueryable<Product> Query(params Expression<Func<Product, object>>[] entitiesToInclude)
        {
            return base.Query(entitiesToInclude).Select(p => new Product()
            {
                Id = p.Id,
                Name = p.Name,
                StockAmount = p.StockAmount,
                Category = p.Category,

                UnitPriceDisplay = p.UnitPrice.ToString("C2", new CultureInfo("en-US")),
                ExpirationDateDisplay = p.ExpirationDate.HasValue ? p.ExpirationDate.Value.ToString("MM/dd/yyyy", new CultureInfo("en-US")) : "",
                IsContinuedDisplay = p.IsContinued ? "Yes" : "No"
            });
        }
    }
}
