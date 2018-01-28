using Mehdime.Entity.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaoBao.Models;
using TaoBao.Repository;

namespace TaoBao.BusinessService
{
    public class GoodsService : BasicBLL<Goods, TbContext>
    {
        GoodsDAL dal = new GoodsDAL();

    }
}