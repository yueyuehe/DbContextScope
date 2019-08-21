using System;
using System.Collections.Generic;
using HWAdmin.BLL.System;
using HWAdmin.DAL.System;
using HWAdmin.Entity.Enum;
using HWAdmin.Entity.System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Runtime.Remoting.Messaging;

namespace TestBLL
{
    [TestClass]
    public class TestBaseBll
    {
        AccountBLL accountBll = new AccountBLL(new AccountDAL());
        [TestMethod]
        public void TestMethod1()
        {
            var list = new List<Account>();
            for (var index = 0; index < 1000000; index++)
            {
                var account = new Account();
                account.AccountName = "liis" + index;
                account.Password = "123" + index;
                account.CreateDate = DateTime.Now;
                account.UpdateDate = DateTime.Now;
                account.DeleteFlg = DeleteFlg.N;
                list.Add(account);
            }
            //accountBll.AddRange(list);
            accountBll.BulkInsert(list);
        }

        [TestMethod]
        public void TestUpdate()
        {
            var list = accountBll.FindList(p => p.AccountName != "").Take(10000);
            foreach (var item in list)
            {
                item.Password = "password";
            }
            accountBll.BulkUpdate(list);


        }


        [TestMethod]
        public void TestFindListAsQueryable()
        {
            var list = accountBll.FindList(p => p.AccountName != "").Take(10);


            string s = "";
        }

        [TestMethod]
        public void TestLocal()
        {
            var file = System.IO.File.Create("D://a.txt");
            file.Dispose();
            file = null;

            CallContext.SetData("add", "value");
            var str = CallContext.GetData("add");

            string s = "";

        }


    }
}
