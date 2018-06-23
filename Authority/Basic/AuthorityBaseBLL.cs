using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authority.Basic
{
    public abstract class AuthorityBaseBLL<TEntity> : BaseBLL<TEntity, AuthorityContext> where TEntity : BaseEntity
    {
    }
}
