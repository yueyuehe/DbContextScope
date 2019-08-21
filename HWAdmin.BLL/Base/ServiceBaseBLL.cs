using HWAdmin.Common.Config;
using HWAdmin.Common.Config.AppStr;
using HWAdmin.Entity.Base;
using HWAdmin.Entity.Enum;
using HWAdmin.Entity.System;
using HWAdmin.IBLL.Base;
using Mehdime.Entity.Extension;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace HWAdmin.BLL.Base
{
    /// <summary>
    /// 业务相关的BLL基类  需要继承此基类
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TDbContext"></typeparam>
    public abstract class ServiceBaseBLL<TEntity> : BasicBLL<TEntity>, IServiceBaseBLL<TEntity> where TEntity : BaseEntity
    {
        #region 账号

        private Account _account = null;


        public ServiceBaseBLL(IBasicDAL<TEntity> dal) : base(dal)
        {

        }

        /// <summary>
        /// 当前用户
        /// </summary>
        protected Account Account
        {
            get
            {
                if (_account == null)
                {
                    var obj = CallContext.LogicalGetData(ConfigParam.Session_Account);
                    if (obj != null)
                    {
                        ///如果不等于空 返回当前对象
                        _account = (Account)CallContext.LogicalGetData(ConfigParam.Session_Account);
                    }
                    else
                    {
                        //返回新的账号
                        _account = new Account();
                    }
                }
                return _account;
            }
        }
        #endregion

        #region 更新

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity"></param>
        public override void Update(TEntity entity)
        {
            entity.UpdateDate = DateTime.Now;
            entity.UpdateUser_Id = Account.Id;
            base.Update(entity);
        }

        /// <summary>
        /// 批量更新
        /// </summary>
        /// <param name="entities"></param>
        public override void UpdateRange(IEnumerable<TEntity> entities)
        {
            foreach (var item in entities)
            {
                item.UpdateDate = DateTime.Now;
                item.UpdateUser_Id = Account.Id;
            }
            base.UpdateRange(entities);
        }

        #endregion

        #region 添加


        /// <summary>
        /// 初始化 必要信息
        /// </summary>
        /// <param name="entity"></param>
        public override void Add(TEntity entity)
        {
            entity.CreateDate = DateTime.Now;
            entity.CreateUser_Id = Account.Id;
            entity.UpdateDate = entity.CreateDate;
            entity.UpdateUser_Id = entity.CreateUser_Id;
            entity.DeleteFlg = DeleteFlg.N;
            base.Add(entity);
        }

        /// <summary>
        /// 批量添加
        /// </summary>
        /// <param name="entities"></param>
        public override void AddRange(IEnumerable<TEntity> entities)
        {
            foreach (var item in entities)
            {
                item.CreateDate = DateTime.Now;
                item.CreateUser_Id = Account.Id;
                item.UpdateDate = item.CreateDate;
                item.UpdateUser_Id = item.CreateUser_Id;
                item.DeleteFlg = DeleteFlg.N;
            }
            base.AddRange(entities);
        }

        #endregion

        #region 逻辑删除


        /// <summary>
        /// 逻辑删除
        /// </summary>
        public void DeleteLogic(TEntity entity)
        {
            entity.DeleteFlg = DeleteFlg.Y;
            Update(entity);
        }

        /// <summary>
        /// 逻辑删除
        /// </summary>
        /// <param name="entities"></param>
        public void DeleteLogic(IEnumerable<TEntity> entities)
        {
            foreach (var item in entities)
            {
                item.DeleteFlg = DeleteFlg.Y;
            }
            UpdateRange(entities);
        }

        /// <summary>
        ///  逻辑删除
        /// </summary>
        /// <param name="id"></param>
        public void DeleteLogic(string id)
        {
            TEntity entity = FindByID(id);
            DeleteLogic(entity);
        }

        /// <summary>
        ///  逻辑删除
        /// </summary>
        /// <param name="id"></param>
        public void DeleteLogic(IEnumerable<string> ids)
        {
            IList<TEntity> list = new List<TEntity>();
            foreach (var item in ids)
            {
                list.Add(FindByID(item));
            }
            DeleteLogic(list);
        }

        #endregion

        #region 物理删除


        /// <summary>
        /// 物理删除
        /// </summary>
        public void DeletePhysical(TEntity entity)
        {
            Remove(entity);
        }


        /// <summary>
        /// 物理删除
        /// </summary>
        /// <param name="entities"></param>
        public void DeletePhysical(IEnumerable<TEntity> entities)
        {
            RemoveRange(entities);
        }


        /// <summary>
        ///  物理删除
        /// </summary>
        /// <param name="id"></param>
        public void DeletePhysical(string id)
        {
            TEntity entity = FindByID(id);
            DeletePhysical(entity);
        }


        /// <summary>
        ///  物理删除
        /// </summary>
        /// <param name="id"></param>
        public void DeletePhysical(IEnumerable<string> ids)
        {
            IList<TEntity> list = new List<TEntity>();
            foreach (var item in ids)
            {
                list.Add(FindByID(item));
            }
            DeletePhysical(list);
        }

        #endregion

    }
}
