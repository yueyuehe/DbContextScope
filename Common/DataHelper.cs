using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
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
            if (string.IsNullOrEmpty(str))
            {
                return 0;
            }
            try
            {
                return Convert.ToDecimal(str);
            }
            catch (Exception e)
            {
                return 0;
            }
        }

        /// <summary>
        /// 转换成Decima类型 不是有效的decimal类型则返回0
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static decimal ToDecimal(object obj)
        {
            if (obj == null || string.IsNullOrEmpty(obj.ToString()))
            {
                return 0;
            }
            return ToDecimal(obj.ToString());
        }


        public static double ToDouble(object obj)
        {
            if (obj == null || string.IsNullOrEmpty(obj.ToString()))
            {
                return 0;
            }
            try
            {
                return Convert.ToDouble(obj);
            }
            catch (Exception e)
            {
                return 0;
            }
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
            try
            {
                Convert.ToDouble(obj);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }


        /// <summary>
        /// 是否可以转换为日期类型
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool TryToDateTime(object obj)
        {
            try
            {
                Convert.ToDateTime(obj);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static bool ToBoolean(object obj)
        {
            try
            {
                return Convert.ToBoolean(obj);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static bool TryToBoolean(object obj)
        {
            try
            {
                Convert.ToBoolean(obj);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }


        /// <summary>
        /// 去除数字末尾的0;
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string NumberFormatter(object obj)
        {
            if (obj == null||string.IsNullOrEmpty(obj.ToString()))
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
    }
}
