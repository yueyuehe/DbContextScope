using Mehdime.Entity.Extension.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Mehdime.Entity.Extension.Implementations
{
    public class BasicDal<TEntity, TDbContext> : IBasicDal<TEntity> where TEntity : class where TDbContext : DbContext
    {
        /// <summary>
        /// DbContext
        /// </summary>
        protected TDbContext context
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

        protected DbContextScopeFactory dbContextScopeFactory = new DbContextScopeFactory();

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Add(TEntity entity)
        {
            context.Set<TEntity>().Add(entity);
        }

        /// <summary>
        /// 批量新增
        /// </summary>
        /// <param name="entities"></param>
        public virtual void AddRange(IEnumerable<TEntity> entities)
        {
            context.Set<TEntity>().AddRange(entities);
        }

        /// <summary>  
        /// 重载。 返回序列中的元素数。   
        /// </summary>  
        /// <returns></returns>  
        public virtual int Count()
        {
            return context.Set<TEntity>().Count();
        }

        /// <summary>  
        /// 重载。 返回满足条件的序列中的元素数。  
        /// </summary>  
        /// <param name="predicate">查询表达式</param>  
        /// <returns></returns>  
        public virtual int Count(Expression<Func<TEntity, bool>> predicate)
        {
            return context.Set<TEntity>().Count(predicate);
        }

        /// <summary>  
        /// 对数据库执行给定的 DDL/DML 命令。 
        /// 与接受 SQL 的任何 API 一样，对任何用户输入进行参数化以便避免 SQL 注入攻击是十分重要的。 
        /// 您可以在 SQL 查询字符串中包含参数占位符，然后将参数值作为附加参数提供。 
        /// 您提供的任何参数值都将自动转换为 DbParameter。
        /// context.Database.ExecuteSqlCommand("UPDATE dbo.Posts SET Rating = 5 WHERE Author = @p0", userSuppliedAuthor); 
        /// 或者，您还可以构造一个 DbParameter 并将它提供给 SqlQuery。 这允许您在 SQL 查询字符串中使用命名参数。
        /// context.Database.ExecuteSqlCommand("UPDATE dbo.Posts SET Rating = 5 WHERE Author = @author", new SqlParameter("@author", userSuppliedAuthor));  
        /// </summary>  
        /// <param name="sql">查询语句</param>  
        /// <returns></returns>  
        public virtual bool ExecuteSqlCommand(string sql, params object[] param)
        {
            return context.Database.ExecuteSqlCommand(sql, param) > 0;
        }

        /// <summary>  
        /// 重载。 确定序列的任何元素是否满足条件。 
        /// （由 QueryableExtensions 定义。）  
        /// </summary>  
        /// <param name="anyLambda"></param>  
        /// <returns></returns>  
        public virtual bool Exists(Expression<Func<TEntity, bool>> anyLambda)
        {
            return context.Set<TEntity>().Any(anyLambda);
        }

        /// <summary>
        /// 按条件查询
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public virtual IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> where)
        {
            return context.Set<TEntity>().Where(where);
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
            return context.Set<TEntity>().Find(key);
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
            var _list = context.Set<TEntity>().Where<TEntity>(whereLambda);
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
            return context.Set<TEntity>().FirstOrDefault<TEntity>(whereLambda);
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
            var _list = context.Set<TEntity>().Where<TEntity>(whereLambda);
            if (isAsc) _list = _list.OrderBy<TEntity, S>(orderLambda);
            else _list = _list.OrderByDescending<TEntity, S>(orderLambda);
            _list = _list.Skip(pageSize * (page - 1)).Take(pageSize);
            return _list;
        }


        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Remove(TEntity entity)
        {
            context.Set<TEntity>().Remove(entity);
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="entities"></param>
        public virtual void RemoveRange(IEnumerable<TEntity> entities)
        {
            context.Set<TEntity>().RemoveRange(entities);
        }

        /// <summary>
        /// 根据ID删除
        /// </summary>
        /// <param name="key"></param>
        public virtual void Remove(object key)
        {
            context.Set<TEntity>().Remove(Find(key));
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="entities"></param>
        public virtual void RemoveRange(params object[] keys)
        {
            foreach (var item in keys)
            {
                Remove(item);
            }
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
        /// context.Blogs.SqlQuery("SELECT * FROM dbo.Posts WHERE Author = @p0", userSuppliedAuthor); 
        /// 或者，您还可以构造一个 DbParameter 并将它提供给 SqlQuery。 
        /// 这允许您在 SQL 查询字符串中使用命名参数。
        /// context.Blogs.SqlQuery("SELECT * FROM dbo.Posts WHERE Author = @author", new SqlParameter("@author", userSuppliedAuthor));  
        /// </summary>  
        /// <param name="sql">sql查询语句</param>  
        public virtual IEnumerable<TEntity> SqlQuery(string sql, params object[] param)
        {
            return context.Database.SqlQuery<TEntity>(sql, param);
        }


        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Update(TEntity entity)
        {
            context.Set<TEntity>().Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }

        /// <summary>
        /// 批量修改
        /// </summary>
        /// <param name="entitys"></param>
        public virtual void UpdateRange(IEnumerable<TEntity> entitys)
        {
            foreach (var item in entitys)
            {
                context.Set<TEntity>().Attach(item);
                context.Entry(item).State = EntityState.Modified;
            }
        }
    }
}
