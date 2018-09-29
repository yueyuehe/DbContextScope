using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("id", typeof(Int32));
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("Time", typeof(DateTime));
            for (var index = 0; index < 10; index++)
            {
               
            }
            string jsonStr = Newtonsoft.Json.JsonConvert.SerializeObject(dt);

            var newDt = Newtonsoft.Json.JsonConvert.DeserializeObject<DataTable>(jsonStr);
            var str = "";


        }
    }
}
