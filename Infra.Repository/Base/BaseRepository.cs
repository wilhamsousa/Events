using Domain.Model.Entity.Base;
using Infra.Repository.Context;
using Infra.Repository.Interface.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Infra.Repository.Base
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity>
            where TEntity : BaseEntity
    {
        protected readonly EventContext Context;

        #region Constructor

        protected BaseRepository(EventContext context)
        {
            Context = context;
        }

        #endregion Constructor

        public virtual TEntity Create(TEntity param)
        {
            CreateId(param);
            var data = Context.Set<TEntity>().Add(param);
            Context.SaveChanges();
            return data.Entity;
        }             

        public virtual void Update(TEntity param)
        {
            var local = Context.Set<TEntity>().Local.FirstOrDefault(entry => entry.Id.Equals(param.Id));
            if (local != null)
                Context.Entry<TEntity>(local).State = EntityState.Detached;

            Context.Entry<TEntity>(param).State = EntityState.Modified;
            var result = Context.Set<TEntity>().Update(param);
            Context.SaveChanges();
        }        

        #region delete
        public virtual void Delete(Guid id)
        {
            var entity = Read(id);
            Delete(entity);
        }

        public virtual void Delete(TEntity param)
        {
            Context.Entry<TEntity>(param).State = EntityState.Detached;
            Context.Set<TEntity>().Remove(param);
            Context.SaveChanges();
        }

        #endregion

        #region Get        

        public virtual TEntity Read(Guid id)
        {
            var entity = Context.Set<TEntity>().AsNoTracking().Where(x => x.Id == id).SingleOrDefault();
            if (entity != null)
                Context.Entry<TEntity>(entity).State = EntityState.Detached;
            return entity;
        }

        public virtual TEntity Read(Expression<Func<TEntity, bool>> match)
        {
            return Context.Set<TEntity>().AsNoTracking().FirstOrDefault(match);
        }

        public virtual TEntity ReadFull(Guid id)
        {
            var entity = Context.Set<TEntity>().Find(id);
            if (entity != null)
                Context.Entry(entity).State = EntityState.Detached;

            return entity;
        }

        public virtual IEnumerable<TEntity> List()
        {
            return Context.Set<TEntity>().AsNoTracking().ToList();
        }

        public virtual IEnumerable<TEntity> List(Expression<Func<TEntity, bool>> match)
        {
            return Context.Set<TEntity>().AsNoTracking().Where(match).ToList();
        }

        public virtual bool Exists(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().Any(predicate);
        }

        public virtual long Count(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().LongCount(predicate);
        }

        public virtual long Count()
        {
            return Context.Set<TEntity>().LongCount();
        }

        #endregion Get

        public virtual long SaveChanges()
        {
            var result = Context.SaveChanges();
            return result;
        }
        public virtual void Detach(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Detached;
        }

        private void CreateId(TEntity param)
        {
            if (param.Id == Guid.Empty)
                param.Id = Guid.NewGuid();
        }
    }
}
