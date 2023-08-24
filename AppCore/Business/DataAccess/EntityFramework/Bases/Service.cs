using AppCore.Records.Bases;
using AppCore.Results;
using AppCore.Results.Bases;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AppCore.Business.DataAccess.EntityFramework.Bases
{
    public abstract class Service<TEntity> : IService<TEntity> where TEntity : Record, new()
    {
        const string ERRORMESSAGE = "Changes not saved!";
        const string ADDEDMESSAGE = "Added successfully.";
        const string UPDATEDMESSAGE = "Updated successfully.";
        const string DELETEDMESSAGE = "Deleted successfully.";

        protected readonly DbContext _db;  // *** sadece bu satýrda new'lenebilir, constructorda new'lenebilir veya dýþarýdan enjekte edilebilir.

        protected Service(DbContext db)
        {
            _db = db;
        }

        public virtual IQueryable<TEntity> Query(params Expression<Func<TEntity, object>>[] entitiesToInclude)
        {
            var query = _db.Set<TEntity>().AsQueryable();
            foreach (var entityToInclude in entitiesToInclude)
            {
                query = query.Include(entityToInclude);
            }
            return query;
        }

        public IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] entitiesToInclude)
        {
            var query = Query(entitiesToInclude);
            query = query.Where(predicate);
            return query;
        }

        public IQueryable<TEntity> QueryAsNoTracking(params Expression<Func<TEntity, object>>[] entitiesToInclude)  // AsNoTracking() -> eðer EF'ün entity üzerinden yapýlan deðiþiklikleri takip etmesini devre dýþý býrakmasýný istiyorsak yapýlýr. 
        {
            return Query(entitiesToInclude).AsNoTracking();
        }

        public IQueryable<TEntity> QueryAsNoTracking(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] entitiesToInclude)
        {
            return QueryAsNoTracking(entitiesToInclude).Where(predicate);
        }

        public virtual Result Add(TEntity entity, bool save = true)
        {
            entity.Guid = Guid.NewGuid().ToString();
            _db.Set<TEntity>().Add(entity);
            if (save)
            {
                Save();
                return new SuccessResult(ADDEDMESSAGE);
            }
            return new ErrorResult(ERRORMESSAGE);
        }

        public virtual Result Update(TEntity entity, bool save = true)
        {
            _db.Set<TEntity>().Update(entity);
            if (save)
            {
                Save();
                return new SuccessResult(UPDATEDMESSAGE);
            }
            return new ErrorResult(ERRORMESSAGE);
        }

        public virtual Result Delete(Expression<Func<TEntity, bool>> predicate, bool save = true)
        {
            var entities = _db.Set<TEntity>().Where(predicate).ToList();
            _db.Set<TEntity>().RemoveRange(entities);
            if (save)
            {
                Save();
                return new SuccessResult(DELETEDMESSAGE);
            }
            return new ErrorResult(ERRORMESSAGE);
        }

        public void Dispose()
        {
            _db?.Dispose();
            GC.SuppressFinalize(this);
        }

        public virtual int Save()
        {
            try
            {
                return _db.SaveChanges();
            }
            catch (Exception ex)
            {
                // ex.Message üzerinden veritabanýndaki log tablosunda veya log dosyasýnda loglama ile beklenmedik hata kayýtlarý tutulabilir.
                // NLog veya Log4Net gibi kütüphaneler üzerinden loglama yönetimi yapýlmasý en uygunudur.
                throw ex;
            }
        }
    }
}
