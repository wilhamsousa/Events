using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repository.Interface.Base
{
    public interface IBaseRepository<TEntity>
    {
        TEntity Create(TEntity param);
        void Update(TEntity param);
        void Delete(Guid id);
        void Delete(TEntity param);
        TEntity Read(Guid id);
        TEntity Read(Expression<Func<TEntity, bool>> match);
        TEntity ReadFull(Guid id);
        IEnumerable<TEntity> List();
        IEnumerable<TEntity> List(Expression<Func<TEntity, bool>> match);
        bool Exists(Expression<Func<TEntity, bool>> predicate);
        long Count(Expression<Func<TEntity, bool>> predicate);
        long Count();
        long SaveChanges();
        void Detach(TEntity entity);

    }
}
