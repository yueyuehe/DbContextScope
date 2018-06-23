using Gift;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace qqliwuwang.BLL
{
    public class ArticleManage
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Article GetArticleById(int id)
        {
            return GiftDB.GetInstance().Single<Article>(id);
        }
    }
}