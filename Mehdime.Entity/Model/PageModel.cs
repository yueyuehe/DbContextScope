using Mehdime.Entity.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Mehdime.Entity.Model
{
    public class PageModel<TEntity> where TEntity : class
    {
        public PageModel()
        {
            DataList = new List<TEntity>();
            OrderType = OrderTypeOption.NONE;
        }
        public IEnumerable<TEntity> DataList { get; set; }

        /// <summary>
        /// 总记录数
        /// </summary>
        public long TotalCount { get; set; }

        /// <summary>
        /// 每页显示的数量
        /// </summary>
        public Int32 PageSize { get; set; }

        /// <summary>
        /// 第几页
        /// </summary>
        public Int32 PageIndex { get; set; }

        /// <summary>
        /// 总页数
        /// </summary>
        public long TotalPage
        {
            get
            {
                return TotalCount % PageSize > 0 ? TotalCount / PageSize + 1 : TotalCount / PageSize;
            }
        }

        public OrderTypeOption OrderType { get; set; }

        /// <summary>
        /// 排序字段
        /// </summary>
        public Expression<Func<TEntity, object>> OrderLambda { get; set; }


    }
}
