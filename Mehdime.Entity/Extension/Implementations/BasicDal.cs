using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Mehdime.Entity.Extension
{
    public class BasicDAL<TEntity, TDbContext> : IBasicDAL<TEntity> where TEntity : class where TDbContext : DbContext
    {
        /// <summary>
        /// DbContext 子类可直接使用
        /// </summary>
        protected TDbContext DbContext
        {
            get
            {
                var _ambientDbContextLocator = new AmbientDbContextLocator();
                var dbContext = _ambientDbContextLocator.Get<TDbContext>();
                if (dbContext == null)
                    throw new InvalidOperationException("No ambient DbContext of type UserManagementDbContext found. This means that this repository method has been called outside of the scope of a DbContextScope. A repository must only be accessed within the scope of a DbContextScope, which takes care of creating the DbContext instances that the repositories need and making them available as ambient contexts. This is what ensures that, for any given DbContext-derived type, the same instance is used throughout the duration of a business transaction. To fix this issue, use IDbContextScopeFactory in your top-level business logic service method to create a DbContextScope that wraps the entire business transaction that your service method implements. Then access this repository within that scope. Refer to the comments in the IDbContextScope.cs file for more details.");
                return dbContext;
            }
        }
      
        #region 查询语句

        /// <summary>  
        /// 重载。 返回序列中的元素数。   
        /// </summary>  
        /// <returns></returns>  
        public virtual int Count()
        {
            return DbContext.Set<TEntity>().Count();
        }

        /// <summary>  
        /// 重载。 返回满足条件的序列中的元素数。  
        /// </summary>  
        /// <param name="predicate">查询表达式</param>  
        /// <returns></returns>  
        public virtual int Count(Expression<Func<TEntity, bool>> predicate)
        {
            return DbContext.Set<TEntity>().Count(predicate);
        }

        /// <summary>  
        /// 对数据库执行给定的 DDL/DML 命令。 
        /// 与接受 SQL 的任何 API 一样，对任何用户输入进行参数化以便避免 SQL 注入攻击是十分重要的。 
        /// 您可以在 SQL 查询字符串中包含参数占位符，然后将参数值作为附加参数提供。 
        /// 您提供的任何参数值都将自动转换为 DbParameter。
        /// DbContext.Database.ExecuteSqlCommand("UPDATE dbo.Posts SET Rating = 5 WHERE Author = @p0", userSuppliedAuthor); 
        /// 或者，您还可以构造一个 DbParameter 并将它提供给 SqlQuery。 这允许您在 SQL 查询字符串中使用命名参数。
        /// DbContext.Database.ExecuteSqlCommand("UPDATE dbo.Posts SET Rating = 5 WHERE Author = @author", new SqlParameter("@author", userSuppliedAuthor));  
        /// </summary>  
        /// <param name="sql">查询语句</param>  
        /// <returns></returns>  
        public virtual bool ExecuteSqlCommand(string sql, params object[] param)
        {
            return DbContext.Database.ExecuteSqlCommand(sql, param) > 0;
        }

        /// <summary>  
        /// 重载。 确定序列的任何元素是否满足条件。 
        /// （由 QueryableExtensions 定义。）  
        /// </summary>  
        /// <param name="anyLambda"></param>  
        /// <returns></returns>  
        public virtual bool Exists(Expression<Func<TEntity, bool>> anyLambda)
        {
            return DbContext.Set<TEntity>().Any(anyLambda);
        }

        /// <summary>
        /// 按条件查询
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public virtual IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> where)
        {
            return DbContext.Set<TEntity>().Where(where);
        }

        /// <summary>  
        /// 查找带给定主键值的实体。 
        /// 如果上下文中存在带给定主键值的实体，则立即返回该实体，
        /// 而不会向存储区发送请求。 
        /// 否则，会向存储区发送查找带给定主键值的实体的请求，
        /// 如果找到该实体，则将其附加到上下文并返回。 
        /// 如果未在上下文或存储区中找到实体，则返回 null。  
        /// </summary>  
        /// <param name="key"></param>  
        /// <returns></returns>  
        public virtual TEntity Find(object key)
        {
            return DbContext.Set<TEntity>().Find(key);
        }


        /// <summary>
        /// 查询集合
        /// </summary>
        /// <typeparam name="S">排序字段</typeparam>
        /// <param name="whereLambda">where条件</param>
        /// <param name="orderLambda">排序</param>
        /// <param name="isAsc">是否升序</param>
        /// <returns></returns>
        public virtual IQueryable<TEntity> FindList<S>(Expression<Func<TEntity, bool>> whereLambda, Expression<Func<TEntity, S>> orderLambda, bool isAsc)
        {
            var _list = DbContext.Set<TEntity>().Where<TEntity>(whereLambda);
            if (isAsc) _list = _list.OrderBy<TEntity, S>(orderLambda);
            else _list = _list.OrderByDescending<TEntity, S>(orderLambda);
            return _list;
        }

        /// <summary>  
        /// 重载。 异步返回序列的第一个元素。  
        /// </summary>  
        /// <param name="whereLambda">查询表达式</param>  
        /// <returns></returns>  
        public virtual TEntity FindOne(Expression<Func<TEntity, bool>> whereLambda)
        {
            return DbContext.Set<TEntity>().FirstOrDefault<TEntity>(whereLambda);
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <typeparam name="S">排序字段</typeparam>
        /// <param name="whereLambda">where条件</param>
        /// <param name="orderLambda">排序条件</param>
        /// <param name="isAsc">是否升序</param>
        /// <param name="page">第几页</param>
        /// <param name="pageSize">每页显示数量</param>
        /// <returns></returns>
        public virtual IQueryable<TEntity> FindPageList<S>(Expression<Func<TEntity, bool>> whereLambda, Expression<Func<TEntity, S>> orderLambda, bool isAsc, int page, int pageSize)
        {
            var _list = DbContext.Set<TEntity>().Where<TEntity>(whereLambda);
            if (isAsc) _list = _list.OrderBy<TEntity, S>(orderLambda);
            else _list = _list.OrderByDescending<TEntity, S>(orderLambda);
            _list = _list.Skip(pageSize * (page - 1)).Take(pageSize);
            return _list;
        }

        /// <summary>  
        /// 创建一个原始 SQL 查询，该查询将返回此集中的实体。 
        /// 默认情况下，上下文会跟踪返回的实体；可通过对返回的 DbSqlQuery<TEntity>
        /// 调用 AsNoTracking 来更改此设置。 
        /// 请注意返回实体的类型始终是此集的类型，而不会是派生的类型。 
        /// 如果查询的一个或多个表可能包含其他实体类型的数据，
        /// 则必须编写适当的 SQL 查询以确保只返回适当类型的实体。
        /// 与接受 SQL 的任何 API 一样，对任何用户输入进行参数化以便避免 SQL 注入攻击是十分重要的。
        /// 您可以在 SQL 查询字符串中包含参数占位符，然后将参数值作为附加参数提供。 
        /// 您提供的任何参数值都将自动转换为 DbParameter。 
        /// DbContext.Blogs.SqlQuery("SELECT * FROM dbo.Posts WHERE Author = @p0", userSuppliedAuthor); 
        /// 或者，您还可以构造一个 DbParameter 并将它提供给 SqlQuery。 
        /// 这允许您在 SQL 查询字符串中使用命名参数。
        /// DbContext.Blogs.SqlQuery("SELECT * FROM dbo.Posts WHERE Author = @author", new SqlParameter("@author", userSuppliedAuthor));  
        /// </summary>  
        /// <param name="sql">sql查询语句</param>  
        public virtual IEnumerable<TEntity> SqlQuery(string sql, params object[] param)
        {
            return DbContext.Database.SqlQuery<TEntity>(sql, param);
        }

        #endregion

        #region 数据库数据操作

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Add(TEntity entity)
        {
            DbContext.Set<TEntity>().Add(entity);
        }

        /// <summary>
        /// 批量新增
        /// </summary>
        /// <param name="entities"></param>
        public virtual void AddRange(IEnumerable<TEntity> entities)
        {
            DbContext.Set<TEntity>().AddRange(entities);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Remove(TEntity entity)
        {
            DbContext.Set<TEntity>().Remove(entity);
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="entities"></param>
        public virtual void RemoveRange(IEnumerable<TEntity> entities)
        {
            DbContext.Set<TEntity>().RemoveRange(entities);
        }
  
        /// <summary>
        /// 根据ID删除
        /// </summary>
        /// <param name="key"></param>
        public virtual void RemoveById(object key)
        {
            DbContext.Set<TEntity>().Remove(Find(key));
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="entities"></param>
        public virtual void RemoveByIds(params object[] keys)
        {
            foreach (var item in keys)
            {
                RemoveById(item);
            }
        }


        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Update(TEntity entity)
        {
            DbContext.Set<TEntity>().Attach(entity);
            DbContext.Entry(entity).State = EntityState.Modified;
        }

        /// <summary>
        /// 批量修改
        /// </summary>
        /// <param name="entitys"></param>
        public virtual void UpdateRange(IEnumerable<TEntity> entitys)
        {
            foreach (var item in entitys)
            {
                DbContext.Set<TEntity>().Attach(item);
                DbContext.Entry(item).State = EntityState.Modified;
            }
        }
        #endregion
    }
}
