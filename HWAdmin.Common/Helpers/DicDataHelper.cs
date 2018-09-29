using HWAdmin.Common.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HWAdmin.Common.Helpers
{
    public class DicDataHelper
    {

        #region Dictionary<string, string>> 模型
        private static Dictionary<string, Dictionary<string, string>> _dic = null;
        private static Dictionary<string, Dictionary<string, string>> GetDicData()
        {
            if (_dic == null)
            {
                //var dic = new Dictionary<string, Dictionary<string, string>>(_dic);
            }
            ///返回的是copy的数据 防止外部给修改
            return new Dictionary<string, Dictionary<string, string>>(_dic);
        }

        /// <summary>
        /// 是否可以替换
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        private static bool IsCanReplace(string code, bool ignoreCase = false)
        {
            var dicData = GetDicData();
            if (dicData[code] != null && dicData[code].Count > 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 获取项  下拉列表
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static Dictionary<string, string> GetDicItem(string code, bool ignoreCase = false)
        {
            return GetDicData()[code];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dicCode"></param>
        /// <param name="dicItemCode"></param>
        /// <param name="ignoreCase">忽略大小写（未实现）</param>
        /// <returns></returns>
        public static string GetDicItemValue(string dicCode, string dicItemCode, bool ignoreCase = false)
        {
            var dicDate = GetDicData();
            if (ignoreCase)
            {
                return dicDate[dicCode][dicItemCode];
            }
            else
            {
                return dicDate[dicCode][dicItemCode];
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="ignoreCase">忽略大小写</param>
        /// <returns></returns>
        public static DataTable DicReplace(DataTable dt, bool ignoreCase = false)
        {
            //数据源
            var dicData = GetDicData();
            //保存要进行字符替换的列
            List<string> list = new List<string>();
            foreach (DataColumn item in dt.Columns)
            {
                ///判断是否可替换
                if (IsCanReplace(item.ColumnName))
                {
                    list.Add(item.ColumnName);
                }
            }
            //遍历替换字符
            foreach (DataRow item in dt.Rows)
            {
                foreach (var columnName in list)
                {
                    var code = item[columnName].ToString();
                    item[columnName] = GetDicItemValue(columnName, code, ignoreCase);
                }
            }
            return dt;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entities"></param>
        /// <param name="ignoreCase"></param>
        /// <returns></returns>
        public static List<T> DicReplace<T>(List<T> entities, bool ignoreCase = false)
        {
            foreach (var item in entities)
            {
                DicReplace(item, ignoreCase);
            }
            return entities;
        }

        /// <summary>
        /// 替换标记字符串
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <param name="ignoreCase"></param>
        /// <returns></returns>
        public static T DicReplace<T>(T entity, bool ignoreCase = false)
        {
            var type = entity.GetType();
            var properties = type.GetProperties();
            foreach (var item in properties)
            {
                if (IsCanReplace(item.Name))
                {
                    item.SetValue(entity, GetDicItemValue(item.Name, item.GetValue(entity).ToString()));
                }
            }
            return entity;
        }

        #endregion

    }
}
