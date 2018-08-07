using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Common.Helpers;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var url = "http://img03.liwushuo.com/image/161109/9drxyugc9.jpg-w720";
            DownHelper.DownLoadFile(url);
        }
    }
}
