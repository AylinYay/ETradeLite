using AppCore.Business.DataAccess.EntityFramework.Bases;
using Business.DataAccess.Contexts;
using Business.DataAccess.Entities;

namespace Business.DataAccess.Services
{
    public abstract class StoreServiceBase : Service<Store>
    {
        protected StoreServiceBase(Db db) : base(db)
        {
        }

        public class StoreService : StoreServiceBase
        {
            public StoreService(Db db) : base(db)
            {
            }
        }
    }
}
