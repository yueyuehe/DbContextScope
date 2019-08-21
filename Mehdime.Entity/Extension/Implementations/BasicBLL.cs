using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Data.Entity;
using Mehdime.Entity.Enums;
using Mehdime.Entity.Model;

namespace Mehdime.Entity.Extension
{

    /// <summary>
    /// 基础业务类的实现 包括增删改查 基础查询
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TDbContext"></typeparam>
    public abstract class BasicBLL<TEntity> : IBasicBLL<TEntity> where TEntity : class
    {
        /// <summary>
        /// 默认的dbContextScopeFactory
        /// </summary>
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

        #region 构造函数

        /// <summary>
        /// 
        /// </summary>
        public BasicBLL(IBasicDAL<TEntity> basicDAL)
        {
            BasicDal = basicDAL;
        }


        public BasicBLL(IDbContextScopeFactory factory)
        {
            this._dbContextScopeFactory = factory;
        }


        public BasicBLL(IBasicDAL<TEntity> basicDAL, IDbContextScopeFactory factory)
        {
            BasicDal = basicDAL;
            this._dbContextScopeFactory = factory;
        }

        #endregion

        /// <summary>
        /// 由子类传递
        /// </summary>
        protected IBasicDAL<TEntity> BasicDal { get; }


        #region 数据操作
        public virtual void Update(TEntity entity)
        {
            using (var dbContextScope = _dbContextScopeFactory.Create())
            {
                BasicDal.Update(entity);
            }
        }

        public virtual void UpdateRange(IEnumerable<TEntity> entities)
        {
            using (var dbContextScope = _dbContextScopeFactory.Create())
            {
                BasicDal.UpdateRange(entities);
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
                BasicDal.Add(entity);
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
                BasicDal.AddRange(entities);
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
                BasicDal.Remove(entity);
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
                BasicDal.RemoveRange(entities);
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
                BasicDal.RemoveById(key);
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
                BasicDal.RemoveByIds(keys);
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
                return BasicDal.Count();
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
                return BasicDal.Count(predicate);
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
                return BasicDal.Exists(anyLambda);
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
                return BasicDal.FindByID(key) == null ? false : true;
            }
        }

        /// <summary>
        /// 根据ID查找
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public virtual TEntity FindByID(object key)
        {
            using (var dbContextScope = _dbContextScopeFactory.CreateReadOnly())
            {
                return BasicDal.FindByID(key);
            }
        }

        /// <summary>
        /// 查询符合条件的第一个
        /// </summary>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        public virtual TEntity FindOne(Expression<Func<TEntity, bool>> whereLambda)
        {
            using (var dbContextScope = _dbContextScopeFactory.CreateReadOnly())
            {
                return BasicDal.FindOne(whereLambda);
            }
        }

        /// <summary>
        /// 查询符合条件的列表
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public virtual IList<TEntity> FindList(Expression<Func<TEntity, bool>> where)
        {
            using (var dbContextScope = _dbContextScopeFactory.CreateReadOnly())
            {
                return BasicDal.Find(where).ToList();
            }
        }


        public virtual IList<TEntity> FindList<S>(Expression<Func<TEntity, bool>> whereLambda, Expression<Func<TEntity, S>> orderLambda, OrderTypeOption orderType)
        {
            using (var dbContextScope = _dbContextScopeFactory.CreateReadOnly())
            {
                var temp = BasicDal.Find(whereLambda);

                switch (orderType)
                {
                    case OrderTypeOption.NONE:
                        break;
                    case OrderTypeOption.ASC:
                        temp.OrderBy(orderLambda);
                        break;
                    case OrderTypeOption.DESC:
                        temp.OrderByDescending(orderLambda);
                        break;
                    default:
                        break;
                }
                return temp.AsNoTracking().ToList();
            }
        }

        /// <summary>
        /// 查询分页数据
        /// </summary>
        /// <typeparam name="S"></typeparam>
        /// <param name="whereLambda"></param>
        /// <param name="orderLambda"></param>
        /// <param name="orderType"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public virtual IList<TEntity> FindPageList<S>(Expression<Func<TEntity, bool>> whereLambda, Expression<Func<TEntity, S>> orderLambda, OrderTypeOption orderType, int pageIndex, int pageSize)
        {
            using (var dbContextScope = _dbContextScopeFactory.CreateReadOnly())
            {
                var temp = BasicDal.Find(whereLambda);
                switch (orderType)
                {
                    case OrderTypeOption.NONE:
                        break;
                    case OrderTypeOption.ASC:
                        temp.OrderBy(orderLambda);
                        break;
                    case OrderTypeOption.DESC:
                        temp.OrderByDescending(orderLambda);
                        break;
                    default:
                        break;
                }
                temp = temp.Skip(pageSize * (pageIndex - 1)).Take(pageSize);
                return temp.ToList();
            }
        }

        /// <summary>
        /// 返回分页模型
        /// </summary>
        /// <param name="whereLambda"></param>
        /// <param name="pageMode"></param>
        /// <returns></returns>
        public virtual PageModel<TEntity> FindPage(Expression<Func<TEntity, bool>> whereLambda, PageModel<TEntity> pageMode)
        {
            using (var dbContextScope = _dbContextScopeFactory.CreateReadOnly())
            {
                var temp = BasicDal.Find(whereLambda);
                switch (pageMode.OrderType)
                {
                    case OrderTypeOption.NONE:
                        break;
                    case OrderTypeOption.ASC:
                        temp.OrderBy(pageMode.OrderLambda);
                        break;
                    case OrderTypeOption.DESC:
                        temp.OrderByDescending(pageMode.OrderLambda);
                        break;
                    default:
                        break;
                }
                temp = temp.Skip(pageMode.PageSize * (pageMode.PageIndex - 1)).Take(pageMode.PageSize).AsNoTracking();
                pageMode.DataList = temp.ToList();
                pageMode.TotalCount = BasicDal.Find(whereLambda).Count();
                return pageMode;
            }


        }

        #endregion

        #region 大批量数据操作


        public virtual void BulkInsert(IEnumerable<TEntity> entities)
        {
            using (var dbContextScope = _dbContextScopeFactory.Create())
            {
                BasicDal.BulkInsert(entities);
                dbContextScope.SaveChanges();
            }
        }

        public virtual void BulkDelete(IEnumerable<TEntity> entities)
        {
            using (var dbContextScope = _dbContextScopeFactory.Create())
            {
                BasicDal.BulkDelete(entities);
                dbContextScope.SaveChanges();
            }
        }

        public virtual void BulkUpdate(IEnumerable<TEntity> entities)
        {
            using (var dbContextScope = _dbContextScopeFactory.Create())
            {
                BasicDal.BulkUpdate(entities);
                dbContextScope.SaveChanges();
            }
        }

        #endregion

        /**
         * AsNoTracking不追踪实体
         * Any  判断是否存在
         * 
         */

        #region 数据查询优化 AsNoTracking不追踪实体
        public IList<TEntity> FindListAsNoTracking(Expression<Func<TEntity, bool>> whereLambda)
        {
            using (var dbContextScope = _dbContextScopeFactory.CreateReadOnly())
            {
                return BasicDal.Find(whereLambda).AsNoTracking().ToList();
            }
        }


        #endregion

        #region 返回Query （必须在Context作用域）

        public virtual IQueryable<TEntity> FindListAsQueryable(Expression<Func<TEntity, bool>> where)
        {
            using (var dbContextScope = _dbContextScopeFactory.CreateReadOnly())
            {
                return BasicDal.Find(where);
            }
        }


        #endregion

        #region 不需要直接执行SQL语句 

        /*
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
             return BasicDal.ExecuteSqlCommand(sql, param);
         }
     }
     public virtual IList<TEntity> SqlQuery(string sql, params object[] param)
     {
         using (var dbContextScope = _dbContextScopeFactory.CreateReadOnly())
         {
             return BasicDal.SqlQuery(sql, param).ToList();
         }
     }
     */


        #endregion

    }
}
