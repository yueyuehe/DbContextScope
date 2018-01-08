using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Data.Entity;

namespace Mehdime.Entity.Extension
{
    public abstract class BasicService<TEntity, TDbContext> : IBasicService<TEntity> where TEntity : class where TDbContext : DbContext
    {
        private IDbContextScopeFactory _dbContextScopeFactory = new DbContextScopeFactory();

        /// <summary>
        /// 用于子类访问DbContextScopeFactory 创建作用域 子类就不用再创建DbContextScopeFactory对象
        /// </summary>
        protected IDbContextScopeFactory DbContextScopeFactory
        {
            get
            {
                return this._dbContextScopeFactory;
            }
        }
        private IBasicDal<TEntity> basicDal = new BasicDal<TEntity, TDbContext>();

        #region 数据操作
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

        /// <summary>  
        /// 将给定实体以“已添加”状态添加到集的基础上下文中，这样一来，
        /// 当调用 SaveChanges 时，会将该实体插入到数据库中。  
        /// </summary>  
        /// <param name="entity">实体</param>  
        /// <returns></returns>  
        public virtual void Add(TEntity entity)
        {
            using (var dbContextScope = _dbContextScopeFactory.Create())
            {
                basicDal.Add(entity);
                dbContextScope.SaveChanges();
            }

        }

        /// <summary>  
        /// 将给定实体集合添加到基础化集的上下文中（每个实体都置于“已添加”状态），
        /// 这样当调用 SaveChanges 时，会将它插入到数据库中。  
        /// </summary>  
        /// <param name="entities">合集</param>  
        /// <returns></returns>  
        public virtual void AddRange(IEnumerable<TEntity> entities)
        {
            using (var dbContextScope = _dbContextScopeFactory.Create())
            {
                basicDal.AddRange(entities);
                dbContextScope.SaveChanges();
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Remove(TEntity entity)
        {
            using (var dbContextScope = _dbContextScopeFactory.Create())
            {
                basicDal.Remove(entity);
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entities"></param>
        public virtual void RemoveRange(IEnumerable<TEntity> entities)
        {
            using (var dbContextScope = _dbContextScopeFactory.Create())
            {
                basicDal.RemoveRange(entities);
            }
        }

        /// <summary>
        /// 根据ID删除
        /// </summary>
        /// <param name="key"></param>
        public virtual void RemoveById(object key)
        {
            using (var dbContextScope = _dbContextScopeFactory.Create())
            {
                basicDal.RemoveById(key);
            }
        }

        /// <summary>
        /// 根据ID删除
        /// </summary>
        /// <param name="keys"></param>
        public virtual void RemoveByIds(params object[] keys)
        {
            using (var dbContextScope = _dbContextScopeFactory.Create())
            {
                basicDal.RemoveByIds(keys);
            }
        }

        #endregion

        #region  数据查询

        /// <summary>
        /// 查询总数
        /// </summary>
        /// <returns></returns>
        public virtual int Count()
        {
            using (var dbContextScope = _dbContextScopeFactory.CreateReadOnly())
            {
                return basicDal.Count();
            }
        }
        /// <summary>
        /// 查询总数
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public virtual int Count(Expression<Func<TEntity, bool>> predicate)
        {
            using (var dbContextScope = _dbContextScopeFactory.CreateReadOnly())
            {
                return basicDal.Count(predicate);
            }
        }

        /// <summary>
        /// 执行数据库语句 ExecuteSqlCommand
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public virtual bool ExecuteSqlCommand(string sql, params object[] param)
        {
            using (var dbContextScope = _dbContextScopeFactory.Create())
            {
                return basicDal.ExecuteSqlCommand(sql, param);
            }
        }

        /// <summary>
        /// 判断是否存在
        /// </summary>
        /// <param name="anyLambda"></param>
        /// <returns></returns>
        public virtual bool Exists(Expression<Func<TEntity, bool>> anyLambda)
        {
            using (var dbContextScope = _dbContextScopeFactory.CreateReadOnly())
            {
                return basicDal.Exists(anyLambda);
            }
        }

        /// <summary>
        /// 判断是否存在
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public virtual bool Exists(object key)
        {
            using (var dbContextScope = _dbContextScopeFactory.CreateReadOnly())
            {
                return basicDal.Find(key)==null?false:true;
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

        public virtual IEnumerable<TEntity> SqlQuery(string sql, params object[] param)
        {
            using (var dbContextScope = _dbContextScopeFactory.CreateReadOnly())
            {
                return basicDal.SqlQuery(sql, param);
            }
        }

        #endregion
    }
}
