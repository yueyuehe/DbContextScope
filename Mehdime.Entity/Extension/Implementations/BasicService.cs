using Mehdime.Entity.Extension.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Data.Entity;

namespace Mehdime.Entity.Extension.Implementations
{
    public abstract class BasicService<TEntity, TDbContext> : IBasicService<TEntity> where TEntity : class where TDbContext : DbContext
    {
        IDbContextScopeFactory _dbContextScopeFactory = new DbContextScopeFactory();
        IBasicDal<TEntity> basicDal = new BasicDal<TEntity, TDbContext>();

        protected DbContext GetDbContext()
        {
            using (var dbContextScope = _dbContextScopeFactory.Create())
            {
                return dbContextScope.DbContexts.Get<TDbContext>();
            }
        }

        public virtual void Add(TEntity entity)
        {
            using (var dbContextScope = _dbContextScopeFactory.Create())
            {
                basicDal.Add(entity);
                dbContextScope.SaveChanges();
            }

        }

        public virtual void AddRange(IEnumerable<TEntity> entities)
        {
            using (var dbContextScope = _dbContextScopeFactory.Create())
            {
                basicDal.AddRange(entities);
                dbContextScope.SaveChanges();
            }
        }

        public virtual int Count()
        {
            using (var dbContextScope = _dbContextScopeFactory.CreateReadOnly())
            {
                return basicDal.Count();
            }
        }

        public virtual int Count(Expression<Func<TEntity, bool>> predicate)
        {
            using (var dbContextScope = _dbContextScopeFactory.CreateReadOnly())
            {
                return basicDal.Count(predicate);
            }
        }

        public virtual bool ExecuteSqlCommand(string sql, params object[] param)
        {
            using (var dbContextScope = _dbContextScopeFactory.Create())
            {
                return basicDal.ExecuteSqlCommand(sql, param);
            }
        }

        public virtual bool Exists(Expression<Func<TEntity, bool>> anyLambda)
        {
            using (var dbContextScope = _dbContextScopeFactory.CreateReadOnly())
            {
                return basicDal.Exists(anyLambda);
            }
        }

        public virtual IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> where)
        {
            using (var dbContextScope = _dbContextScopeFactory.CreateReadOnly())
            {
                return basicDal.Find(where);
            }
        }

        public virtual TEntity Find(object key)
        {
            using (var dbContextScope = _dbContextScopeFactory.CreateReadOnly())
            {
                return basicDal.Find(key);
            }
        }

        public virtual IQueryable<TEntity> FindList<S>(Expression<Func<TEntity, bool>> whereLambda, Expression<Func<TEntity, S>> orderLambda, bool isAsc)
        {
            using (var dbContextScope = _dbContextScopeFactory.CreateReadOnly())
            {
                return basicDal.FindList<S>(whereLambda, orderLambda, isAsc);
            }
        }

        public virtual TEntity FindOne(Expression<Func<TEntity, bool>> whereLambda)
        {
            using (var dbContextScope = _dbContextScopeFactory.CreateReadOnly())
            {
                return basicDal.FindOne(whereLambda);
            }
        }

        public virtual IQueryable<TEntity> FindPageList<S>(Expression<Func<TEntity, bool>> whereLambda, Expression<Func<TEntity, S>> orderLambda, bool isAsc, int page, int pageSize)
        {
            using (var dbContextScope = _dbContextScopeFactory.CreateReadOnly())
            {
                return basicDal.FindPageList<S>(whereLambda, orderLambda, isAsc, page, pageSize);
            }
        }

        public virtual void Remove(TEntity entity)
        {
            using (var dbContextScope = _dbContextScopeFactory.Create())
            {
                basicDal.Remove(entity);
            }
        }

        public virtual void RemoveRange(IEnumerable<TEntity> entities)
        {
            using (var dbContextScope = _dbContextScopeFactory.Create())
            {
                basicDal.RemoveRange(entities);
            }
        }

        public virtual IEnumerable<TEntity> SqlQuery(string sql, params object[] param)
        {
            using (var dbContextScope = _dbContextScopeFactory.CreateReadOnly())
            {
                return basicDal.SqlQuery(sql, param);
            }
        }

        public virtual void Update(TEntity entity)
        {
            using (var dbContextScope = _dbContextScopeFactory.Create())
            {
                basicDal.Update(entity);
            }
        }

        public virtual void UpdateRange(IEnumerable<TEntity> entity)
        {
            using (var dbContextScope = _dbContextScopeFactory.Create())
            {
                basicDal.UpdateRange(entity);
            }
        }
    }
}
