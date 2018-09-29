using Gift;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using PetaPoco;

namespace qqliwuwang.BLL
{
    public class ArticleManage : BaseBLL<Qq_Article>
    {

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <param name="queryModel"></param>
        /// <param name="orderFild"></param>
        /// <param name="isAsc"></param>
        /// <returns></returns>
        public override Page<Qq_Article> Page(long page, long limit, Qq_Article queryModel, string orderFild, string orderType = "ASC")
        {
            var sql = new StringBuilder("select * from t_qq_Articles where 1=1 ");
            var param = new List<SqlParameter>();
            if (!string.IsNullOrEmpty(queryModel.Title))
            {
                sql.Append(" and Title like @Title ");
                param.Add(new SqlParameter("@Title", queryModel.Title));
            }
            if (!string.IsNullOrEmpty(queryModel.Author))
            {
                sql.Append(" and Author like @Author ");
                param.Add(new SqlParameter("@Author", queryModel.Author));
            }
            if (!string.IsNullOrEmpty(queryModel.HeadContent))
            {
                sql.Append(" and HeadContent like @HeadContent ");
                param.Add(new SqlParameter("@HeadContent", queryModel.HeadContent));
            }
            //排序
            if (!string.IsNullOrEmpty(orderFild))
            {
                sql.Append(string.Format(" order by {0} {1} ", orderFild, orderType));
            }
            return GiftDB.GetInstance().Page<Qq_Article>(page, limit, sql.ToString(), param.ToArray());
        }

    }
}