using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Common.Helpers
{
    /// <summary>
    /// 数据处理
    /// </summary>
    public class DataHelper
    {
        /// <summary>
        /// 转换成Decima类型 不是有效的decimal类型则返回0
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static decimal ToDecimal(string str)
        {
            Decimal.TryParse(str, out decimal number);
            return number;
        }

        /// <summary>
        /// 转换成Decima类型 不是有效的decimal类型则返回0
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static decimal ToDecimal(object obj)
        {
            return ToDecimal(obj.ToString());
        }

        public static Double ToDouble(string str)
        {
            Double.TryParse(str, out Double number);
            return number;
        }
        public static double ToDouble(object obj)
        {
            return ToDouble(obj.ToString());
        }

        public static DateTime ToDateTime(object obj)
        {
            return Convert.ToDateTime(obj);
        }

        /// <summary>
        /// 是否可以转换为double类型
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool TryToDouble(object obj)
        {
            var result = Double.TryParse(obj.ToString(), out Double number);
            return result;
        }


        /// <summary>
        /// 是否可以转换为日期类型
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool TryToDateTime(object obj)
        {
            var result = DateTime.TryParse(obj.ToString(), out DateTime date);
            return result;
        }

        public static bool ToBoolean(object obj)
        {
            Boolean.TryParse(obj.ToString(), out Boolean result);
            return result;
        }

        /// <summary>
        /// 判断能否转成bool类型
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool TryToBoolean(object obj)
        {
            var result = Boolean.TryParse(obj.ToString(), out Boolean date);
            return result;
        }


        /// <summary>
        /// 去除数字末尾的0;
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string NumberFormatter(object obj)
        {
            if (obj == null || string.IsNullOrEmpty(obj.ToString()))
            {
                return "0";
            }
            var value = obj.ToString();
            if (string.IsNullOrEmpty(value))
            {
                return "0";
            }
            else
            {
                if (value.IndexOf('.') > 0)
                {
                    value = value.TrimEnd('0').TrimEnd('.');
                }
                else
                {
                    value = value.TrimStart('0');
                }
                if (value.Length == 0)
                {
                    return "0";
                }
                return value;
            }
        }

        /// <summary>
        /// 集合转DataTable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <returns></returns>
        public static DataTable ToDataTable<T>(IEnumerable<T> collection)
        {
            var props = typeof(T).GetProperties();
            var dt = new DataTable();
            dt.Columns.AddRange(props.Select(p => new DataColumn(p.Name, p.PropertyType)).ToArray());
            if (collection.Count() > 0)
            {
                for (int i = 0; i < collection.Count(); i++)
                {
                    ArrayList tempList = new ArrayList();
                    foreach (PropertyInfo pi in props)
                    {
                        object obj = pi.GetValue(collection.ElementAt(i), null);
                        tempList.Add(obj);
                    }
                    object[] array = tempList.ToArray();
                    dt.LoadDataRow(array, true);
                }
            }
            return dt;
        }

        public static IList<T> ToList<T>(DataTable dt) where T : new()
        {
            /*kd
            // 定义集合    
            IList < T > list = new List<T>();
            // 获得此模型的类型   
            Type type = typeof(T);
            string tempName = "";
            foreach (DataRow dr in dt.Rows)
            {
                T model = new T();
                // 获得此模型的公共属性      
                PropertyInfo[] propertys = model.GetType().GetProperties();
                foreach (PropertyInfo pi in propertys)
                {
                    tempName = pi.Name;
                    // 检查DataTable是否包含此列    
                    if (dt.Columns.Contains(tempName))
                    {
                        // 判断此属性是否有Setter      
                        if (!pi.CanWrite) continue;
                        object value = dr[tempName];
                        if (value != DBNull.Value)
                            pi.SetValue(model, value, null);
                    }
                }
                list.Add(model);
            }
            */
            var list = new List<T>();
            var jsondata = Newtonsoft.Json.JsonConvert.SerializeObject(dt);
            list = Newtonsoft.Json.JsonConvert.DeserializeObject<List<T>>(jsondata);
            return list;
        }
    }
}
