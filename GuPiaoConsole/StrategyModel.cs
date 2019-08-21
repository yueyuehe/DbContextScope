using GP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuPiaoConsole
{
    public class StrategyModel
    {
        //获取从哪天开始投 
        string startDate = "2016-06-01";
        string endDate = "2018-02-15";
        //买卖手续费
        decimal Rate = 0.0015M;
        /// <summary>
        /// 每期投的金额
        /// </summary>
        decimal UnitPrice = 50;


        //计算收益  每期定投  跌倒多少加仓收益率大
        public Dictionary<string, decimal> ComputerV1(decimal[] chanshus)
        {
            //总投资
            decimal totalAmount = 0;
            //总手续费
            decimal totalRate = 0;
            //总市值
            decimal MarketValue = 50;

            decimal Benjin = 50;


            //定投期数
            var data = GetData(startDate, endDate);
            for (var i = 0; i < data.Count - 1; i++)
            {
                //投入当天的数值
                var item = data[i];
                //计算收盘后的市值
                MarketValue = MarketValue * (1 + item.Risefall.Value * 0.01M);
                //计算当前收益
                var diff = (MarketValue - Benjin) / Benjin;
                //如果收益为负 并且小于 一个值倍投
                var ratio = 1;
                if (diff < chanshus[0])
                {
                    ratio = ratio * 7;
                }
                if (diff < chanshus[1])
                {
                    ratio = ratio * 7;
                }
                //定投金额
                var touprice = UnitPrice * ratio;
                //计算买卖手续费
                var ratePrice = Rate * touprice;
                totalRate = totalRate + ratePrice;
                //计算本金
                Benjin = Benjin + UnitPrice * ratio;
                //加仓后的市值
                MarketValue = MarketValue + touprice - ratePrice;
            }
            var dic = new Dictionary<string, decimal>();
            dic.Add("市值", MarketValue);
            dic.Add("本金", Benjin);
            dic.Add("手续费", totalRate);
            dic.Add("收益金额", MarketValue - Benjin);
            dic.Add("收益率", (MarketValue - Benjin) / Benjin);
            dic.Add("振幅", (data[data.Count - 1].ClosePrice.Value - data[0].ClosePrice.Value) / data[0].ClosePrice.Value);
            dic.Add("投资期数", data.Count);
            dic.Add("应投本金", data.Count * UnitPrice);
            return dic;
        }




        /// <summary>
        /// 执行策略
        /// </summary>
        public void ActionStrategy1()
        {
            /// <summary>
            /// 本金
            /// </summary>
            decimal Capital = 0;
            /// <summary>
            /// 市值 持有金额
            /// </summary>
            decimal MarketValue = 0;

            decimal RateTotal = 0;
            //获取从哪天开始投 
            var data = GetData(startDate, endDate);
            var maxsy = 0M;

            for (var i = 0; i < data.Count - 1; i++)
            {
                //投入当天的数值
                var item = data[i];
                //计算市值
                MarketValue = MarketValue * (1 + item.Risefall.Value * 0.01M);
                var ratePrice = Rate * UnitPrice;
                RateTotal = RateTotal + ratePrice;
                //计算本金
                Capital = Capital + UnitPrice;
                //加仓后的市值
                MarketValue = MarketValue + UnitPrice - ratePrice;
                var itemshouyilu = (MarketValue - Capital) / Capital;
                if (itemshouyilu > maxsy)
                {
                    maxsy = itemshouyilu;
                }
            }

            var shouyi = MarketValue - Capital;
            var shouyilu = (MarketValue - Capital) / Capital;

            Console.WriteLine("本金:" + Capital);
            Console.WriteLine("市值:" + MarketValue);
            Console.WriteLine("手续费:" + RateTotal);
            Console.WriteLine("收益:" + shouyi);
            Console.WriteLine("收益率:" + shouyilu * 100 + "%");
            Console.WriteLine("最大收益率:" + maxsy);

        }


        public DataModel ActionStrategy11(decimal ratio, decimal chanshu)
        {
            /// <summary>
            /// 本金
            /// </summary>
            decimal Capital = 50;
            /// <summary>
            /// 市值 持有金额
            /// </summary>
            decimal MarketValue = 50;

            decimal RateTotal = 50 * Rate;
            //获取从哪天开始投 
            var data = GetData(startDate, endDate);
            var maxsy = 0M;

            for (var i = 0; i < data.Count - 1; i++)
            {
                //投入当天的数值
                var item = data[i];
                //计算市值
                MarketValue = MarketValue * (1 + item.Risefall.Value * 0.01M);

                //如果当前市值减去成本  涨幅小于 -5%
                //diff< 指定数加仓  diff>指定数 减仓
                var diff = (MarketValue - Capital) / Capital;
                if (diff < chanshu)
                {
                    var itemprice = Math.Abs((chanshu - diff) * ratio * UnitPrice);
                    var price = itemprice + UnitPrice;
                    Capital = Capital + price;
                    RateTotal = RateTotal + (price * Rate);
                    MarketValue = MarketValue + price - (price * Rate);
                }
                else
                {
                    Capital = Capital + UnitPrice;
                    RateTotal = RateTotal + (UnitPrice * Rate);
                    MarketValue = MarketValue + UnitPrice - (UnitPrice * Rate);
                }
                var itemshouyilu = (MarketValue - Capital) / Capital;
                if (itemshouyilu > maxsy)
                {
                    maxsy = itemshouyilu;
                }
            }

            var shouyi = MarketValue - Capital;
            var shouyilu = (MarketValue - Capital) / Capital;

            var model = new DataModel();
            model.Capital = Capital;
            model.MarketValue = MarketValue;
            model.RateTotal = RateTotal;
            model.Shouyi = shouyi;
            model.Shouyilu = shouyilu;
            //Console.WriteLine("本金:" + Capital);
            //Console.WriteLine("市值:" + MarketValue);
            //Console.WriteLine("手续费:" + RateTotal);
            //Console.WriteLine("收益:" + shouyi);
            //Console.WriteLine("收益率:" + shouyilu * 100 + "%");
            //Console.WriteLine("最大收益率:" + maxsy);
            return model;
        }

        public DataModel ActionStrategyV2(List<decimal> chanshus)
        {
            /// <summary>
            /// 本金
            /// </summary>
            decimal Capital = 2500;
            /// <summary>
            /// 市值 持有金额
            /// </summary>
            decimal MarketValue = 2500;

            decimal RateTotal = 2500 * Rate;
            //获取从哪天开始投 
            var data = GetData(startDate, endDate);
            var maxsy = 0M;
            var model = new DataModel();

            for (var i = 0; i < data.Count - 1; i++)
            {

                //投入当天的数值
                var item = data[i];
                //计算市值
                MarketValue = MarketValue * (1 + item.Risefall.Value * 0.01M);

                //如果当前市值减去成本  涨幅小于 -5%
                //diff< 指定数加仓  diff>指定数 减仓
                var diff = (MarketValue - Capital) / Capital;
                var ratio = 1;
                if (diff < chanshus[0])
                {
                    ratio = ratio * 7;
                    model.Live1++;
                }
                if (diff < chanshus[1] && chanshus[0] - 0.02M > chanshus[1])
                {
                    ratio = ratio * 7;
                    model.Live2++;
                }

                var itemprice = ratio * UnitPrice;
                var price = itemprice;
                Capital = Capital + price;
                RateTotal = RateTotal + (price * Rate);
                MarketValue = MarketValue + price - (price * Rate);

                var itemshouyilu = (MarketValue - Capital) / Capital;
                if (itemshouyilu > maxsy)
                {
                    maxsy = itemshouyilu;
                }
            }

            var shouyi = MarketValue - Capital;
            var shouyilu = (MarketValue - Capital) * 100 / Capital;

            model.Capital = Capital;
            model.MarketValue = MarketValue;
            model.RateTotal = RateTotal;
            model.Shouyi = shouyi;
            model.Shouyilu = shouyilu;
            //Console.WriteLine("本金:" + Capital);
            //Console.WriteLine("市值:" + MarketValue);
            //Console.WriteLine("手续费:" + RateTotal);
            //Console.WriteLine("收益:" + shouyi);
            //Console.WriteLine("收益率:" + shouyilu * 100 + "%");
            //Console.WriteLine("最大收益率:" + maxsy);
            return model;
        }


        public void ActionStrategy2()
        {
            /// <summary>
            /// 本金
            /// </summary>
            decimal Capital = 0;
            /// <summary>
            /// 市值 持有金额
            /// </summary>
            decimal MarketValue = 0;
            //预计市值
            decimal ShouldValue = 0;
            /// <summary>
            /// 每期投的金额
            /// </summary>
            //取现
            decimal OutPrice = 0;
            decimal RateTotal = 0;
            var data = GetData(startDate, endDate);

            for (var i = 0; i < data.Count - 1; i++)
            {
                //投入当天股市的数值
                var item = data[i];
                //计算今日收市市值
                MarketValue = MarketValue * (1 + (item.Risefall.Value / 100M));
                //计算预期市值
                ShouldValue = ShouldValue + UnitPrice;
                //计算应该加的市值
                //计算每次应该加或者出的数据
                var price = (MarketValue - ShouldValue);
                var ratePrice = Rate * Math.Abs(price);
                RateTotal = RateTotal + ratePrice;
                if (price < 0)
                {
                    //实际比预期小
                    Capital = Capital + Math.Abs(price);
                    MarketValue = MarketValue + Math.Abs(price) - ratePrice;
                }
                else
                {
                    //实际比预期大
                    OutPrice = OutPrice + Math.Abs(price) - ratePrice;
                    MarketValue = MarketValue - Math.Abs(price);
                }
            }

            var shouyi = MarketValue - (Capital - OutPrice);
            var shouyilu = shouyi / (Capital - OutPrice);
            var lixiang = shouyi / ShouldValue;

            Console.WriteLine("本金:" + Capital);
            Console.WriteLine("实际本金:" + (Capital - OutPrice));
            Console.WriteLine("取现:" + OutPrice);
            Console.WriteLine("市值:" + MarketValue);
            Console.WriteLine("预期市值:" + ShouldValue);
            Console.WriteLine("手续费:" + RateTotal);
            Console.WriteLine("收益:" + shouyi);
            Console.WriteLine("收益率:" + shouyilu * 100 + "%");
            Console.WriteLine("理想收益率:" + lixiang * 100 + "%");
        }

        public DataModel ActionStrategy3(decimal inRate, decimal outRate)
        {
            /// <summary>
            /// 本金
            /// </summary>
            decimal Capital = 0;
            /// <summary>
            /// 市值 持有金额
            /// </summary>
            decimal MarketValue = 0;
            //预计市值
            decimal ShouldValue = 0;
            /// <summary>
            /// 每期投的金额
            /// </summary>
            //取现
            decimal OutPrice = 0;
            decimal RateTotal = 0;
            var data = GetData(startDate, endDate);

            for (var i = 0; i < data.Count - 1; i++)
            {
                //投入当天股市的数值
                var item = data[i];
                //计算今日收市市值
                MarketValue = MarketValue * (1 + item.Risefall.Value / 100M);
                //计算预期市值
                ShouldValue = ShouldValue + UnitPrice;

                var price = (MarketValue - ShouldValue);

                //计算每次应该加或者出的数据
                var ratePrice = Rate * Math.Abs(price);
                RateTotal = RateTotal + ratePrice;

                //计算偏离
                if (price / ShouldValue < inRate)
                {
                    //小于 则补仓
                    Capital = Capital + Math.Abs(price);
                    MarketValue = MarketValue + Math.Abs(price) - ratePrice;
                }
                else if (price / ShouldValue > outRate)
                {
                    //大于 则减仓
                    OutPrice = OutPrice + Math.Abs(price) - ratePrice;
                    MarketValue = MarketValue - Math.Abs(price);
                }
                else
                {
                    price = UnitPrice;
                    Capital = Capital + Math.Abs(price);
                    MarketValue = MarketValue + Math.Abs(price) - ratePrice;
                }
            }

            var shouyi = MarketValue - (Capital - OutPrice);
            var shouyilu = shouyi / (Capital - OutPrice);
            var lixiang = shouyi / ShouldValue;

            var dataModel = new DataModel();
            dataModel.inRate = inRate;
            dataModel.outRate = outRate;
            dataModel.Capital = Capital;
            dataModel.TrueCapital = Capital - OutPrice;
            dataModel.OutPrice = OutPrice;
            dataModel.MarketValue = MarketValue;
            dataModel.ShouldValue = ShouldValue;
            dataModel.RateTotal = RateTotal;
            dataModel.Shouyi = shouyi;
            dataModel.Shouyilu = shouyilu;
            dataModel.Lixiang = lixiang;
            return dataModel;
        }


        public DataModel ActionStrategy4(decimal inRate, decimal outRate)
        {

            /// <summary>
            /// 本金
            /// </summary>
            decimal Capital = 0;
            /// <summary>
            /// 市值 持有金额
            /// </summary>
            decimal MarketValue = 0;
            //预计市值
            decimal ShouldValue = 0;
            /// <summary>
            /// 每期投的金额
            /// </summary>
            //取现
            decimal OutPrice = 0;
            decimal RateTotal = 0;
            var data = GetData(startDate, endDate);

            for (var i = 0; i < data.Count - 1; i++)
            {
                //投入当天股市的数值
                var item = data[i];
                //计算今日收市市值
                MarketValue = MarketValue * (1 + item.Risefall.Value * 0.01M);
                //计算预期市值
                ShouldValue = ShouldValue + UnitPrice;

                var price = 0M;
                //计算偏离
                if ((MarketValue - ShouldValue) / ShouldValue < inRate)
                {
                    //小于
                    price = ShouldValue - MarketValue;
                }
                else if ((MarketValue - ShouldValue) / ShouldValue > outRate)
                {
                    //大于
                    price = ShouldValue - MarketValue;
                }
                else
                {
                    price = UnitPrice;
                }


                //计算每次应该加或者出的数据

                var ratePrice = Rate * price;
                RateTotal = RateTotal + ratePrice;
                if (price < 0)
                {
                    OutPrice = OutPrice + price - ratePrice;
                }
                else
                {
                    Capital = Capital + price;
                }
                //加仓后的市值
                MarketValue = MarketValue + price - ratePrice;
            }

            var shouyi = MarketValue - (Capital + OutPrice);
            var shouyilu = shouyi / (Capital + OutPrice);
            var lixiang = shouyi / ShouldValue;

            var dataModel = new DataModel();
            dataModel.inRate = inRate;
            dataModel.outRate = outRate;
            dataModel.Capital = Capital;
            dataModel.TrueCapital = Capital + OutPrice;
            dataModel.OutPrice = OutPrice;
            dataModel.MarketValue = MarketValue;
            dataModel.ShouldValue = ShouldValue;
            dataModel.RateTotal = RateTotal;
            dataModel.Shouyi = shouyi;
            dataModel.Shouyilu = shouyilu;
            dataModel.Lixiang = lixiang;
            return dataModel;
        }
        private List<T_SHISHU_INFO> GetData(string startDate, string endDate)
        {
            var db = new DBContext();
            var sql = "SELECT * FROM dbo.T_SHISHU_INFO  WHERE Date BETWEEN @0 AND @1 ORDER BY Date ASC";
            return db.Query<T_SHISHU_INFO>(sql, startDate, endDate).ToList();
        }



    }

    public class DataModel
    {
        public decimal Capital { get; set; }
        public decimal TrueCapital { get; set; }
        public decimal OutPrice { get; set; }
        public decimal MarketValue { get; set; }
        public decimal ShouldValue { get; set; }
        public decimal RateTotal { get; set; }
        public decimal Shouyi { get; set; }
        public decimal Shouyilu { get; set; }
        public decimal Lixiang { get; set; }

        public Int32 Live1 { get; set; }


        public Int32 Live2 { get; set; }


        public decimal inRate { get; set; }

        public decimal outRate { get; set; }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("本金:" + Capital);
            sb.AppendLine();
            sb.Append("实际本金:" + (Capital - OutPrice));
            sb.AppendLine();
            sb.Append("取现:" + OutPrice);
            sb.AppendLine();
            sb.Append("市值:" + MarketValue);
            sb.AppendLine();

            sb.Append("预期市值:" + ShouldValue);
            sb.AppendLine();

            sb.Append("手续费:" + RateTotal);
            sb.AppendLine();

            sb.Append("收益:" + Shouyi);
            sb.AppendLine();

            sb.Append("收益率:" + Shouyilu * 100 + "%");
            sb.AppendLine();
            sb.Append("理想收益率:" + Lixiang * 100 + "%");
            sb.AppendLine();
            return sb.ToString();
        }
    }
}
