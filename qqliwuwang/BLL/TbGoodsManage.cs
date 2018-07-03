using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Gift;
using PetaPoco;
using qqliwuwang.Helper;
using System.Text;

namespace qqliwuwang.BLL
{
    /// <summary>
    /// 淘宝商品操作类
    /// </summary>
    public class TbGoodsManage : BaseBLL<Qq_TbGood>
    {
        public override Page<Qq_TbGood> Page(long page, long limit, Qq_TbGood queryModel, string orderFild, string orderType = "ASC")
        {
            var sql = new StringBuilder("select * from t_qq_TbGoods where 1=1 ");
            var index = 0;
            List<object> parames = new List<object>();
            ///淘宝标题
            if (!string.IsNullOrEmpty(queryModel.Name))
            {
                sql.Append(" and Name like @" + index++);
                parames.Add(queryModel.Name);
            }
            ///标题
            if (!string.IsNullOrEmpty(queryModel.Title))
            {
                sql.Append(" and Title like @" + index++);
                parames.Add(queryModel.Title);
            }
            ///导语
            if (!string.IsNullOrEmpty(queryModel.HeadContent))
            {
                sql.Append(" and HeadContent like @" + index++);
                parames.Add(queryModel.HeadContent);
            }
            if (!string.IsNullOrEmpty(queryModel.DeleteFlag))
            {
                sql.Append(" and DeleteFlag like @" + index++);
                parames.Add(queryModel.DeleteFlag);
            }
            //排序
            if (!string.IsNullOrEmpty(orderFild))
            {
                sql.Append(string.Format(" order by {0} {1} ", orderFild, orderType));
            }
            return CurrentDB.Page<Qq_TbGood>(page, limit, sql.ToString(), parames.ToArray());
        }
    }
}