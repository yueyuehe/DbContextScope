using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HWAdmin.IBLL.Base
{

    /// <summary>
    /// 业务的base
    /// </summary>
    public interface IServiceBaseBLL<TEntity> where TEntity : class
    {

        void DeleteLogic(TEntity entity);
        void DeleteLogic(IEnumerable<TEntity> entities);

        void DeleteLogic(string id);


        void DeleteLogic(IEnumerable<string> ids);

        void DeletePhysical(TEntity entity);

        void DeletePhysical(IEnumerable<TEntity> entities);

        void DeletePhysical(string id);

        void DeletePhysical(IEnumerable<string> ids);
    }
}
