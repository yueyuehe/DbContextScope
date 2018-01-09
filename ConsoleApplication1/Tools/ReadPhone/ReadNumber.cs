using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Tools.ReadPhone
{
    /// <summary>
    /// 读取excel中的数据(获取人名以及电话)
    /// </summary>
    public class ReadNumber
    {

        /// <summary>
        /// 获取电话号码及人名
        /// </summary>
        /// <param name="path"></param>
        public Dictionary<string, string> ReadPhone(string path)
        {
            var dt = Common.NPOIHelper.ImportExceltoDt(path);

            var dic = new Dictionary<string, string>();
            foreach (DataRow item in dt.Rows)
            {
                var name = item[4].ToString().Trim();
                var phone1 = item[5].ToString().Trim();
                var phone2 = item[6].ToString().Trim();
                var phone3 = item[7].ToString().Trim();
                var phone4 = item[8].ToString().Trim();
                if (phone1.Length > 0)
                {
                    if (!dic.ContainsKey(phone1))
                    {
                        dic.Add(phone1, name);
                    }
                }
                if (phone2.Length > 0)
                {
                    if (!dic.ContainsKey(phone2))
                    {
                        dic.Add(phone2, name);
                    }
                }
                if (phone3.Length > 0)
                {
                    if (!dic.ContainsKey(phone3))
                    {
                        dic.Add(phone3, name);
                    }
                }
                if (phone4.Length > 0)
                {
                    if (!dic.ContainsKey(phone4))
                    {
                        dic.Add(phone4, name);
                    }
                }
            }
            return dic;
        }



        public void WriteToTxt(Dictionary<string, string> dic)
        {
            var dt = new DataTable();
            dt.Columns.Add("name");
            dt.Columns.Add("phone");
            foreach (var item in dic)
            {
                var row = dt.NewRow();
                row[0] = item.Value;
                row[1] = item.Key;
                dt.Rows.Add(row);
            }
            Common.NPOIHelper.ExportDTtoExcel(dt, "", @"F:/a.xls");
        }


        public void ComputeNumber(long start, long end)
        {
            //计算潍坊学院的电话号码

            FileStream file = new FileStream("F:/"+ start .ToString().Substring(0,7)+ ".txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            TextWriter write = new StreamWriter(file);
            for (; start <= end; start++)
            {
                write.Write(start);
                write.WriteLine();
            }
            write.Close();
            file.Close();
            string s = "";

        }
    }
}
