using AppCore.Business.DataAccess.EntityFramework.Bases;
using Business.DataAccess.Contexts;
using Business.DataAccess.Entities;
using System.Linq.Expressions;

namespace Business.DataAccess.Services
{
    public abstract class StoreServiceBase : Service<Store>
    {
        protected StoreServiceBase(Db db) : base(db)
        {
        }
    }

    public class StoreService : StoreServiceBase
    {
        public StoreService(Db db) : base(db)
        {
        }

        public override IQueryable<Store> Query(params Expression<Func<Store, object>>[] entitiesToInclude)
        {
            return base.Query(entitiesToInclude).Select(s => new Store()
            {
                Name = s.Name,
                IsVirtual = s.IsVirtual,
                Guid = s.Guid,
                Id = s.Id,

                IsVirtualDisplay = s.IsVirtual ? "Yes" : "No"
            });
        }
    }  
}
