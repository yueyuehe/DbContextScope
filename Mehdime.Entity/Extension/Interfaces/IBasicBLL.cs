using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Mehdime.Entity.Extension
{
    public interface IBasicBLL<TEntity> where TEntity : class
    {
        #region 数据操作

        /// <summary>  
        /// 将给定实体以“已添加”状态添加到集的基础上下文中，这样一来，
        /// 当调用 SaveChanges 时，会将该实体插入到数据库中。  
        /// </summary>  
        /// <param name="entity">实体</param>  
        /// <returns></returns>  
        void Add(TEntity entity);

        /// <summary>  
        /// 将给定实体集合添加到基础化集的上下文中（每个实体都置于“已添加”状态），
        /// 这样当调用 SaveChanges 时，会将它插入到数据库中。  
        /// </summary>  
        /// <param name="entities">合集</param>  
        /// <returns></returns>  
        void AddRange(IEnumerable<TEntity> entities);

        /// <summary>  
        /// 将给定实体标记为“已删除”，这样一来，当调用 SaveChanges 时，将从数据库中删除该实体。 请注意，在调用此方法之前，该实体必须以另一种状态存在于该上下文中。  
        /// </summary>  
        /// <param name="entity">实体</param>  
        /// <returns></returns>  
        void Remove(TEntity entity);

        /// <summary>  
        /// 从基础化集的上下文中删除给定实体集合（每个实体都置于“已删除”状态），这样当调用 SaveChanges 时，会从数据库中删除它。  
        /// </summary>  
        /// <param name="entities">合集</param>  
        /// <returns></returns>  
        void RemoveRange(IEnumerable<TEntity> entities);

        /// <summary>
        /// 根据ID删除
        /// </summary>
        /// <param name="key"></param>
        void RemoveById(object key);

        /// <summary>
        /// 根据Id删除
        /// </summary>
        /// <param name="keys"></param>
        void RemoveByIds(params object[] keys);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="entity"></param>
        void Update(TEntity entity);

        /// <summary>
        /// 批量修改
        /// </summary>
        /// <param name="entity"></param>
        void UpdateRange(IEnumerable<TEntity> entity);
        #endregion


        #region 数据查询
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
        TEntity Find(object key);

        /// <summary>  
        /// 重载。 异步返回序列的第一个元素。  
        /// </summary>  
        /// <param name="whereLambda">查询表达式</param>  
        /// <returns></returns>  
        TEntity FindOne(Expression<Func<TEntity, bool>> whereLambda);

        /// <summary>
        /// 按条件查询
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        IList<TEntity> Find(Expression<Func<TEntity, bool>> where);

        /// <summary>
        /// 查询集合
        /// </summary>
        /// <typeparam name="S">排序字段</typeparam>
        /// <param name="whereLambda">where条件</param>
        /// <param name="orderLambda">排序</param>
        /// <param name="isAsc">是否升序</param>
        /// <returns></returns>
        IList<TEntity> FindList<S>(Expression<Func<TEntity, bool>> whereLambda, Expression<Func<TEntity, S>> orderLambda, bool isAsc);

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
        IList<TEntity> FindPageList<S>(Expression<Func<TEntity, bool>> whereLambda, Expression<Func<TEntity, S>> orderLambda, bool isAsc, int page, int pageSize);


        //6.0  
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
        IList<TEntity> SqlQuery(string sql, params object[] param);


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
        bool ExecuteSqlCommand(string sql, params object[] param);

        /// <summary>  
        /// 重载。 确定序列的任何元素是否满足条件。 
        /// （由 QueryableExtensions 定义。）  
        /// </summary>  
        /// <param name="anyLambda"></param>  
        /// <returns></returns>  
        bool Exists(Expression<Func<TEntity, bool>> anyLambda);

        /// <summary>
        /// 判断是否存在
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        bool Exists(object key);
        /// <summary>  
        /// 重载。 返回序列中的元素数。 （由 QueryableExtensions 定义。）  
        /// </summary>  
        /// <returns></returns>  
        int Count();

        /// <summary>  
        /// 重载。 返回满足条件的序列中的元素数。  
        /// </summary>  
        /// <param name="predicate">查询表达式</param>  
        /// <returns></returns>  
        int Count(Expression<Func<TEntity, bool>> predicate);

        #endregion
    }
}
