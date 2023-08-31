using AppCore.Business.DataAccess.EntityFramework.Bases;
using AppCore.Results;
using AppCore.Results.Bases;
using Business.DataAccess.Contexts;
using Business.DataAccess.Entities;
using System.Linq.Expressions;

namespace Business.DataAccess.Services
{
    public abstract class CategoryServiceBase : Service<Category>
    {
        protected CategoryServiceBase(Db db) : base(db)
        {
        }
    }

    public class CategoryService : CategoryServiceBase
    {
        public CategoryService(Db db) : base(db)
        {
        }

        public override IQueryable<Category> Query(params Expression<Func<Category, object>>[] entitiesToInclude)
        {
            return base.Query(entitiesToInclude).OrderBy(c => c.Name).Select(c => new Category()
            {
                Description = c.Description,
                Guid = c.Guid,
                Id = c.Id,
                Name = c.Name,
                Products = c.Products,

                ProductCountDisplay = c.Products.Count,
                ProductsDisplay = string.Join("<br />", c.Products.Select(p => p.Name))
            });
        }

        public override Result Add(Category entity, bool save = true)
        {
            if (Exists(c => c.Name.ToUpper() == entity.Name.ToUpper().Trim()))
                return new ErrorResult("Category with same name exists!");
            entity.Name = entity.Name.Trim();
            entity.Description = entity.Description?.Trim();
            return base.Add(entity, save);
        }

        public override Result Update(Category entity, bool save = true)
        {
            if (Exists(c => c.Name.ToUpper() == entity.Name.ToUpper().Trim() && c.Id != entity.Id))
                return new ErrorResult("Category with same name exists!");
            entity.Name = entity.Name.Trim();
            entity.Description = entity.Description?.Trim();
            return base.Add(entity, save);
        }

        public override Result Delete(Expression<Func<Category, bool>> predicate, bool save = true)
        {
            var category = Query().SingleOrDefault(predicate);
            if (category.Products != null && category.Products.Count > 0)
            {
                //_db.Set<Product>().RemoveRange(category.Products);
                return new ErrorResult("Category cannot be deleted because it has products!");
            }
            return base.Delete(predicate, save);
        }
    }
}
