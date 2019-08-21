using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HWAdmin.Common.Extensions;

namespace GuPiaoConsole
{
    class Program
    {
        static void Main2(string[] args)
        {
            var model = new StrategyModel();
            model.ActionStrategy1();
            Console.WriteLine("**********");
            model.ActionStrategy2();
            Console.WriteLine("**********");

            var list = new List<DataModel>();
            var xxlist = new List<decimal> { -0.09M, -0.1M };
            var xxxlist = new List<decimal> { -0.14M, -0.13M };
            foreach (var xx in xxlist)
            {
                foreach (var xxx in xxxlist)
                {
                    var cs = new List<decimal> { xx, xxx };
                    var item = model.ActionStrategyV2(cs);
                    item.inRate = xx;
                    item.outRate = xxx;
                    list.Add(item);
                }
            }

            list = list
                   //.Where(p => p.inRate > p.outRate)
                   .OrderBy(p => p.Capital).ThenByDescending(p => p.Shouyilu).ToList();
            var dt = list.ToDataTable();


            string s = "";

            // model.ActionStrategy11(100);
            // Console.WriteLine("**********");
            /*
            var list = new List<DataModel>();
            for (var i = -0.01M; i > -1; i = i - 0.01M)
            {
                for (var x = 0.01M; x < 1; x = x + 0.01M)
                {
                    var itemModel = model.ActionStrategy3(i, x);
                    list.Add(itemModel);
                }
            }
            var query = list.OrderByDescending(p => p.Shouyi).Take(10);
            foreach (var item in query)
            {
                var str = item.ToString();
                Console.WriteLine(str);
                Console.WriteLine("inrate：" + item.inRate);
                Console.WriteLine("outRate：" + item.outRate);

                Console.WriteLine("--------------------");
            }
            */
            Console.Read();
        }


        static void Main(string[] arges)
        {
            StrategyModel model = new StrategyModel();

            List<Dictionary<string, decimal>> dic = new List<Dictionary<string, decimal>>();
            for (var i = 0M; i > -0.3M; i = i - 0.01M)
            {
                for (var k = i; k > -0.3M; k = k - 0.01M)
                {
                    var cs = new List<decimal> { i, k };
                    var item = model.ComputerV1(cs.ToArray());
                    item.Add("第一梯度收益率", i);
                    item.Add("第二梯度收益率", k);
                    dic.Add(item);
                }
            }
            var datatable = new DataTable();
            datatable.Columns.Add("市值", typeof(decimal));
            datatable.Columns.Add("本金", typeof(decimal));
            datatable.Columns.Add("手续费", typeof(decimal));
            datatable.Columns.Add("收益金额", typeof(decimal));
            datatable.Columns.Add("收益率", typeof(decimal));
            datatable.Columns.Add("振幅", typeof(decimal));
            datatable.Columns.Add("投资期数", typeof(decimal));
            datatable.Columns.Add("应投本金", typeof(decimal));
            datatable.Columns.Add("第一梯度收益率", typeof(decimal));
            datatable.Columns.Add("第二梯度收益率", typeof(decimal));

            foreach (var item in dic)
            {
                var dt = item.ToDataTable();
                var row = datatable.NewRow();
                row[0] = dt.Rows[0][1];
                row[1] = dt.Rows[1][1];
                row[2] = dt.Rows[2][1];
                row[3] = dt.Rows[3][1];
                row[4] = dt.Rows[4][1];
                row[5] = dt.Rows[5][1];
                row[6] = dt.Rows[6][1];
                row[7] = dt.Rows[7][1];
                row[8] = dt.Rows[8][1];
                row[9] = dt.Rows[9][1];
                datatable.Rows.Add(row);
            }
            var sst = datatable.DefaultView.Sort = "本金 ASC, 收益率 DESC";
            var dtt = datatable.DefaultView.ToTable();
            string s = "";
        }
    }
}
