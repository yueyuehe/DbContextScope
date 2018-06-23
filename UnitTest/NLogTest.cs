using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Common;
using System.Collections.Generic;
using System.Linq.Expressions;
using Common.Helpers;
using Common.Enums;

namespace UnitTest
{
    [TestClass]
    public class NLogTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var logger = NLog.LogManager.GetCurrentClassLogger();
            logger.Info("Hello World");
            logger.Error("Hello World");
        }

        [TestMethod]
        public void TestMethod2()
        {
            var g1 = Md5.Encrypt("asd");
            var g2 = Md5.Encrypt("asd");
        }

        [TestMethod]
        public void TestMethod3()
        {
            string s = FlgDel.N.ToString();

            string ss = s;
        }

        [TestMethod]
        public void TestMethod4()
        {
            Params p1 = new Params() { ID = "0", Name = "0name", Des = "0des", PID = "" };
            Params p2 = new Params() { ID = "1", Name = "1name", Des = "1des", PID = "0" };
            Params p3 = new Params() { ID = "2", Name = "2name", Des = "2des", PID = "0" };
            Params p4 = new Params() { ID = "3", Name = "3name", Des = "3des", PID = "2" };

            List<Params> list = new List<Params>();
            list.Add(p1);
            list.Add(p2);
            list.Add(p3);
            list.Add(p4);
            // TreeItem<Params> item1 = new TreeItem<Params>();
            // TreeItem<Params> item2 = new TreeItem<Params>();
            // TreeItem<Params> item3 = new TreeItem<Params>();
            // TreeItem<Params> item4 = new TreeItem<Params>();
            //
            // item1.Item = p1;
            // item2.Item = p2;
            // item3.Item = p3;
            // item4.Item = p4;

            var item = GenericHelpers.GenerateTree<Params, string>(list, m => m.ID, m => m.PID, "0");

            string s = JsonHelper.Instance.Serialize(item);


        }


        [TestMethod]
        public void Testmetnod5()
        {
            Params p = new Params();
            p.Name = "123";
            var str = GetXXX<Params, string>(m => m.Name);

        }

        [TestMethod]
        public void Testmetnod6()
        {
            var e1 = FlgDel.N | FlgDel.Y;
            var e2 = FlgDel.N;

            if (e1 == e2) {
                var ss = "";
            }

            var sss = "";

        }



        public string GetXXX<T, TT>(Expression<Func<T, TT>> ex)
        {

            var member = ex.Body as MemberExpression;
            var colstr = "";
            if (member != null)
                colstr = member.Member.Name;

            return colstr;
        }

        public class Params
        {
            public string ID { get; set; }
            public string Name { get; set; }
            public string Des { get; set; }
            public string PID { get; set; }

        }
    }





    public enum FlgDel
    {
        N = 1,
        Y = 2,
        X = 4,
        Z = 8
    }


}
