using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region << 版 本 注 释 >>
/*----------------------------------------------------------------
* 项目名称 ：SpiderConsole
* 项目描述 ：
* 类 名 称 ：shuangseqiu
* 类 描 述 ：
* 所在的域 ：yueyuehe-PC
* 命名空间 ：SpiderConsole
* 机器名称 ：YUEYUEHE-PC 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：yueyuehe
* 创建时间 ：2018/6/15 0:14:28
* 更新时间 ：2018/6/15 0:14:28
* 版 本 号 ：v1.0.0.0
*******************************************************************
* Copyright @ yueyuehe 2018. All rights reserved.
*******************************************************************
//----------------------------------------------------------------*/
#endregion
namespace SpiderConsole
{
    public class DoubleBall
    {
        public void ProduceNum()
        {
            Random random = new Random();
            int[] ball = new int[7];
            int count = 0;
            while (count < 7)
            {
                int num = (random.Next(33) + 1);
                bool flag = true;
                for (int i = 0; i < count; i++)
                {
                    if (num == ball[i])
                    {
                        flag = false;
                        break;
                    }
                }
                if (flag)
                {
                    ball[count] = num;
                    count++;
                }
            }
            //Arrays.sort(in);  
            ball[6] = random.Next(16) + 1;
            Array.Sort(ball, 0, 6);
            for (int i = 0; i < ball.Count(); i++)
            {
                Console.Write(ball[i] + " ");
            }
        }

        public void Main(string[] args)
        {
            while (true)
            {
                DoubleBall doubleBall = new DoubleBall();
                doubleBall.ProduceNum();
                Console.WriteLine();
            }
           // Console.Read();
        }
    }
}
