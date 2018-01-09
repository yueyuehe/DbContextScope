using ConsoleApplication1.Module.User;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\hewei\Desktop\华为手机助手2018-01-09_100712063.xlsx";
            var model = new Tools.ReadPhone.ReadNumber();
            var dic = model.ReadPhone(path);
            model.ComputeNumber(15882270501, 15882278999);
        }


        public void Test()
        {
            var stopwatch = new Stopwatch();
            stopwatch.Restart();
            var bll = new UserService();
            Console.WriteLine("创建业务时间{0}", stopwatch.ElapsedMilliseconds);
            stopwatch.Restart();
            var user = new Person();
            user.Name = "李四";
            Console.WriteLine("创建实体对象时间{0}", stopwatch.ElapsedMilliseconds);

            stopwatch.Restart();
            bll.Add(user);
            Console.WriteLine("保存事件{0}", stopwatch.ElapsedMilliseconds);

            var user2 = new Person();
            user2.Name = "张三";
            stopwatch.Restart();
            bll.Add(user);
            Console.WriteLine("保存事件{0}", stopwatch.ElapsedMilliseconds);

            Console.WriteLine("保存成功");
            Console.Read();
        }
    }
}
