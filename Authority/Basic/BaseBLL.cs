using Common.Config;
using Common.Config.AppStr;
using Mehdime.Entity.Extension;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Authority.Basic
{
    public abstract class BaseBLL<TEntity, TDbContext> : BasicBLL<TEntity, TDbContext> where TEntity : BaseEntity where TDbContext : DbContext
    {
        #region 账号

        private Account _account = null;

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


        public override void Update(TEntity entity)
        {
            entity.UpdateDate = DateTime.Now;
            entity.UpdateUser_Id = Account.Id;
            base.Update(entity);
        }

        public override void UpdateRange(IEnumerable<TEntity> entities)
        {
            foreach (var item in entities)
            {
                item.UpdateDate = DateTime.Now;
                item.UpdateUser_Id = Account.Id;
            }
            base.UpdateRange(entities);
        }

        /// <summary>
        /// 初始化话 必要信息
        /// </summary>
        /// <param name="entity"></param>
        public override void Add(TEntity entity)
        {
            entity.CreateDate = DateTime.Now;
            entity.CreateUser_Id = Account.Id;
            entity.UpdateDate = entity.CreateDate;
            entity.UpdateUser_Id = entity.CreateUser_Id;
            entity.FlgDel = FlgDel.N;
            base.Add(entity);
        }

        public override void AddRange(IEnumerable<TEntity> entities)
        {
            foreach (var item in entities)
            {
                item.CreateDate = DateTime.Now;
                item.CreateUser_Id = Account.Id;
                item.UpdateDate = item.CreateDate;
                item.UpdateUser_Id = item.CreateUser_Id;
                item.FlgDel = FlgDel.N;
            }

            base.AddRange(entities);
        }

        /// <summary>
        /// 逻辑删除
        /// </summary>
        public void DeleteLogic(TEntity entity)
        {
            entity.FlgDel = FlgDel.Y;
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
                item.FlgDel = FlgDel.Y;
            }
            UpdateRange(entities);
        }

        /// <summary>
        ///  逻辑删除
        /// </summary>
        /// <param name="id"></param>
        public void DeleteLogic(string id)
        {
            TEntity entity = Find(id);
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
                list.Add(Find(item));
            }
            DeleteLogic(list);
        }
    }
}
