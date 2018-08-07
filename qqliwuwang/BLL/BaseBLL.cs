using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using qqliwuwang.Helper;
using System.Text;
using PetaPoco;
using System.Data.SqlClient;

namespace qqliwuwang.BLL
{
    public abstract class BaseBLL<T>
    {


        protected Gift.GiftDB CurrentDB { get { return Helper.DBHelper.CurrentDB(); } }

        /// <summary>
        /// 当前用户
        /// </summary>
        public Entity.Account LoginUser { get { return CommonHelper.LoginUser(); } }

        /// <summary>
        /// 根据ID获取对象
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T FindById(int id)
        {
            return DBHelper.CurrentDB().Single<T>(id);
        }


        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="model"></param>
        public void Save(T model)
        {
            DBHelper.CurrentDB().Save(model);
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="list"></param>
        public void Save(IList<T> list)
        {
            using (var scope = DBHelper.CurrentDB().GetTransaction())
            {
                foreach (var item in list)
                {
                    DBHelper.CurrentDB().Save(item);
                    DBHelper.CurrentDB().CompleteTransaction();
                }
            }

        }


        /// <summary>
        /// 插入 返回新的ID
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public Int32 Insert(T model)
        {
            var id = DBHelper.CurrentDB().Insert(model);
            return (Int32)id;
        }


        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="model"></param>
        public void Update(T model)
        {
            DBHelper.CurrentDB().Update(model);
        }


        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="list"></param>
        public void Update(List<T> list)
        {
            using (var scope = DBHelper.CurrentDB().GetTransaction())
            {
                foreach (var item in list)
                {
                    DBHelper.CurrentDB().Update(item);
                }
            }
        }


        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="arr"></param>
        public void Delete(params Int32[] arr)
        {
            foreach (var item in arr)
            {
                DBHelper.CurrentDB().Delete<T>(item);
            }
        }


        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public abstract Page<T> Page(long page, long limit, T queryModel, string orderFild, string isAsc);

    }
}