using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PetaPoco;
using Gift;
using System.Runtime.Remoting.Messaging;

namespace qqliwuwang.Helper
{
    public class DBHelper
    {
        /// <summary>
        /// 返回新的Db获取线程中国的DB
        /// </summary>
        /// <returns></returns>
        public static GiftDB CurrentDB()
        {
            var db = CallContext.LogicalGetData("current_DB") as GiftDB;
            if (db == null)
            {
                db = Gift.GiftDB.GetInstance();
                CallContext.LogicalSetData("current_DB", db);
            }
            return db;
        }
    }
}