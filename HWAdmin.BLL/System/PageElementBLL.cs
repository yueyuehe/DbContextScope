﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mehdime.Entity.Extension;
using HWAdmin.BLL.Base;
using HWAdmin.Entity.System;
using HWAdmin.IBLL.System;
using HWAdmin.IDAL.System;

namespace HWAdmin.BLL.System
{
    /// <summary>
    /// 页面元素业务类
    /// </summary>
    public class PageElementBLL : SysBaseBLL<PageElement>, IPageElementBLL
    {
        public PageElementBLL(IPageElementDAL dal) : base(dal)
        {
        }
    }
}
