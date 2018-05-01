using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HWAdmin.Unit
{
    /// <summary>
    /// 作为一般页的返回类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PageResponse
    {

        public PageResponse()
        {
            page = 1;
            limit = 20;
            msg = "";
            sort = "";
            order = "asc";

        }

        /// <summary>
        /// 成功的状态码
        /// </summary>
        public int code { get; set; }
        /// <summary>
        /// 状态信息 
        /// </summary>
        public string msg { get; set; }
        /// <summary>
        /// 列表数据
        /// </summary>
        public object data { get; set; }
        /// <summary>
        /// 页码
        /// </summary>
        public int page { get; set; }
        /// <summary>
        /// 每页数量
        /// </summary>
        public int limit { get; set; }
        /// <summary>
        /// 总记录数
        /// </summary>
        public int count { get; set; }

        /// <summary>
        /// 总页数
        /// </summary>
        public int totalPage
        {
            get
            {

                if (count % limit == 0)
                {
                    return count / limit;
                }
                return count / limit + 1;

            }
        }
       
        /// <summary>
        /// 保存其他信息
        /// </summary>
        public object context { get; set; }
        /// <summary>
        /// 排序列名
        /// </summary>
        public string sort { get; set; }

        /// <summary>
        /// 升序or降序
        /// </summary>
        public string order { get; set; }


    }

    public static class QueryableExtendsions
    {
        public static PageResponse ToPageResponse<TSource>(this IQueryable<TSource> source)
        {
            var pageModel = new PageResponse();
            pageModel.count = source.Count();
            pageModel.data = source.Skip((pageModel.page - 1) * pageModel.limit).Take(pageModel.limit).ToList();
            return pageModel;
        }
        public static PageResponse ToPageResponse<TSource>(this IQueryable<TSource> source, PageResponse page)
        {
            page.count = source.Count();
            page.data = source.Skip((page.page - 1) * page.limit).Take(page.limit).ToList();
            return page;
        }

    }

}
/// <summary>
/// 一般返回信息
/// </summary>
public class MsgResponse
{
    public bool Status = true;
    public string Message = "操作成功";
    public dynamic Result;
}


