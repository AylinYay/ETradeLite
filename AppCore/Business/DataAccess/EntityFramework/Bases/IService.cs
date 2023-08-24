using AppCore.Records.Bases;
using AppCore.Results.Bases;
using System.Linq.Expressions;

namespace AppCore.Business.DataAccess.EntityFramework.Bases
{
    public interface IService<TEntity> : IDisposable where TEntity : Record, new()
    {
        IQueryable<TEntity> Query(params Expression<Func<TEntity, object>>[] entitiesTOInclude);   // read

        Result Add(TEntity entity, bool save = true);

        Result Update(TEntity entity, bool save = true);

        Result Delete(Expression<Func<TEntity, bool>> predicate, bool save = true);

        int Save();
    }
}
