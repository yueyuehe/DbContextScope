using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HWAdmin.Common.Extensions
{
    /// <summary>
    /// 常用的扩展方法
    /// </summary>
    public static class DataExtendsions
    {
        /// <summary>
        /// 将对象的属性映射到T对象(只映射属性名相同的属性/属性是复杂对象是引用传递)
        /// </summary>
        /// <typeparam name="T">要映射返回的对象类型</typeparam>
        /// <param name="model">object 对象</param>
        /// <returns></returns>
        public static T MapperTo<T>(this object model)
        {
            T a = Activator.CreateInstance<T>();
            Type Typeb = model.GetType();//获得类型  
            Type Typea = typeof(T);
            foreach (PropertyInfo sp in Typeb.GetProperties())//获得类型的属性字段  
            {
                foreach (PropertyInfo ap in Typea.GetProperties())
                {
                    if (ap.Name == sp.Name)//判断属性名是否相同  
                    {
                        ap.SetValue(a, sp.GetValue(model, null), null);//获得b对象属性的值复制给a对象的属性  
                    }
                }
            }
            return a;
        }

        /// <summary>
        /// 集合转为DataTable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <returns></returns>
        public static DataTable ToDataTable<T>(this IEnumerable<T> collection)
        {
            List<T> list = collection.ToList();
            var props = typeof(T).GetProperties();
            var dt = new DataTable();
            var columnList = new List<DataColumn>();
            foreach (var item in props)
            {
                if (item.PropertyType.IsGenericType && item.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                {
                    //columnList.Add(new DataColumn(item.Name, typeof(string)));
                    columnList.Add(new DataColumn(item.Name, item.PropertyType.GetGenericArguments()[0]));
                }
                else
                {
                    columnList.Add(new DataColumn(item.Name, item.PropertyType));
                }
            }

            // dt.Columns.AddRange(props.Select(p => new DataColumn(p.Name, p.PropertyType)).ToArray());
            dt.Columns.AddRange(columnList.ToArray());
            if (list.Count() > 0)
            {
                for (int i = 0; i < list.Count(); i++)
                {
                    ArrayList tempList = new ArrayList();
                    foreach (PropertyInfo pi in props)
                    {
                        object obj = pi.GetValue(list.ElementAt(i), null);
                        tempList.Add(obj);
                    }
                    object[] array = tempList.ToArray();
                    dt.LoadDataRow(array, true);
                }
            }
            return dt;
        }

        /// <summary>
        /// 格式化时间类型（去除 0001/01/01 1753/01/01 之类的）
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DataTable FormatDate(this DataTable dt)
        {
            var dtTypeCloList = new List<string>();
            foreach (DataColumn item in dt.Columns)
            {
                if (item.DataType == typeof(DateTime))
                {
                    dtTypeCloList.Add(item.ColumnName);
                }
            }
            foreach (DataRow item in dt.Rows)
            {
                foreach (var colName in dtTypeCloList)
                {
                    if (item[colName].GetType() != typeof(DBNull))
                    {
                        var year = ((DateTime)item[colName]).Year;
                        if (year == 1 || year == 1753)
                        {
                            item[colName] = DBNull.Value;
                        }
                    }
                }
            }
            return dt;
        }

        /// <summary>
        /// 对象转为Dic格式  
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static IDictionary<string, object> ToDictionary(this object model)
        {
            IDictionary<string, object> dic = new Dictionary<string, object>();
            Type Typeb = model.GetType();//获得类型  
            foreach (PropertyInfo sp in Typeb.GetProperties())//获得类型的属性字段  
            {
                dic.Add(sp.Name, sp.GetValue(model));
            }
            return dic;
        }

        /// <summary>
        /// 将 data 中的项添加到source中 isCover 表示相同键是否覆盖原有值
        /// </summary>
        /// <param name="source"></param>
        /// <param name="data"></param>
        /// <param name="isCover"></param>
        /// <returns></returns>
        public static IDictionary<TKey, TValue> Merge<TKey, TValue>(this IDictionary<TKey, TValue> source, IDictionary<TKey, TValue> data, bool isCover = false)
        {
            if (data == null || data.Count == 0)
            {
                return source;
            }
            else
            {
                foreach (var item in data)
                {
                    if (source.ContainsKey(item.Key))
                    {
                        if (isCover)
                        {
                            source[item.Key] = item.Value;
                        }
                    }
                    else
                    {
                        source.Add(item.Key, item.Value);
                    }


                }
            }
            return source;

        }


        public static IList<T> ToList<T>(this DataTable dt) where T : new()
        {
            /*
            // 定义集合    
            IList<T> list = new List<T>();
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
