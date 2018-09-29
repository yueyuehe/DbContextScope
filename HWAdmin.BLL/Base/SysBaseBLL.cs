using HWAdmin.BLL.Base;
using HWAdmin.DAL.Context;
using HWAdmin.Entity.Base;
using Mehdime.Entity.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HWAdmin.BLL.Base
{
    public abstract class SysBaseBLL<TEntity> : BasicBLL<TEntity, SysContext> where TEntity : BaseEntity
    {

    }
}
