using AppCore.Business.DataAccess.EntityFramework.Bases;
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
            return base.Query(entitiesToInclude).OrderBy(c => c.Name);
        }
    }
}
