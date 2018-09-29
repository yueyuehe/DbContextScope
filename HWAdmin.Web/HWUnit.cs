using AutoMapper;
using log4net;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace UnitTestEF
{
    public class HWUnit
    {
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




    }

    public class Md5
    {
        public static string Encrypt(string str)
        {
            string pwd = String.Empty;
            MD5 md5 = MD5.Create();
            // 编码UTF8/Unicode　
            byte[] s = md5.ComputeHash(Encoding.UTF8.GetBytes(str));
            // 转换成字符串
            for (int i = 0; i < s.Length; i++)
            {
                //格式后的字符是小写的字母
                //如果使用大写（X）则格式后的字符是大写字符
                pwd = pwd + s[i].ToString("X");
            }
            return pwd;
        }
    }

    /// <summary>
    /// 常用的扩展方法
    /// </summary>
    public static class HWExtendsions
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
    }

    #region 版本问题


    public static class AutoMapperExt
    {
        /// <summary>
        ///  类型映射
        /// </summary>
        public static T MapTo<T>(this object obj)
        {
            if (obj == null) return default(T);
            // Mapper.CreateMap(obj.GetType(), typeof(T));
            Mapper.Initialize(m => m.CreateMap(obj.GetType(), typeof(T)));

            return Mapper.Map<T>(obj);
        }

        /// <summary>
        /// 集合列表类型映射
        /// </summary>
        public static List<TDestination> MapToList<TDestination>(this IEnumerable source)
        {
            foreach (var first in source)
            {
                var type = first.GetType();
                //  Mapper.CreateMap(type, typeof(TDestination));
                Mapper.Initialize(m => m.CreateMap(type, typeof(TDestination)));
                break;
            }
            return Mapper.Map<List<TDestination>>(source);
        }

        /// <summary>
        /// 集合列表类型映射
        /// </summary>
        public static List<TDestination> MapToList<TSource, TDestination>(this IEnumerable<TSource> source)
        {
            //IEnumerable<T> 类型需要创建元素的映射
            //Mapper.CreateMap<TSource, TDestination>();
            Mapper.Initialize(m => m.CreateMap<TSource, TDestination>());

            return Mapper.Map<List<TDestination>>(source);
        }

        /// <summary>
        /// 类型映射
        /// </summary>
        public static TDestination MapTo<TSource, TDestination>(this TSource source, TDestination destination)
            where TSource : class
            where TDestination : class
        {
            if (source == null) return destination;
            //Mapper.CreateMap<TSource, TDestination>();
            Mapper.Initialize(m => m.CreateMap<TSource, TDestination>());
            return Mapper.Map(source, destination);
        }

        /// <summary>
        /// DataReader映射
        /// </summary>
        public static IEnumerable<T> DataReaderMapTo<T>(this IDataReader reader)
        {
            Mapper.Reset();
            //Mapper.CreateMap<IDataReader, IEnumerable<T>>();
            Mapper.Initialize(m => m.CreateMap<IDataReader, IEnumerable>());
            return Mapper.Map<IDataReader, IEnumerable<T>>(reader);
        }
    }

    #endregion

    /// <summary>
    /// 常用公共类
    /// </summary>
    public class CommonHelper
    {
        #region Stopwatch计时器
        /// <summary>
        /// 计时器开始
        /// </summary>
        /// <returns></returns>
        public static Stopwatch TimerStart()
        {
            Stopwatch watch = new Stopwatch();
            watch.Reset();
            watch.Start();
            return watch;
        }
        /// <summary>
        /// 计时器结束
        /// </summary>
        /// <param name="watch"></param>
        /// <returns></returns>
        public static string TimerEnd(Stopwatch watch)
        {
            watch.Stop();
            double costtime = watch.ElapsedMilliseconds;
            return costtime.ToString();
        }
        #endregion

        #region 删除数组中的重复项
        /// <summary>
        /// 删除数组中的重复项
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public static string[] RemoveDup(string[] values)
        {
            List<string> list = new List<string>();
            for (int i = 0; i < values.Length; i++)//遍历数组成员
            {
                if (!list.Contains(values[i]))
                {
                    list.Add(values[i]);
                };
            }
            return list.ToArray();
        }
        #endregion

        #region 自动生成日期编号
        /// <summary>
        /// 自动生成编号  201008251145409865
        /// </summary>
        /// <returns></returns>
        public static string CreateNo()
        {
            Random random = new Random();
            string strRandom = random.Next(1000, 10000).ToString(); //生成编号 
            string code = DateTime.Now.ToString("yyyyMMddHHmmss") + strRandom;//形如
            return code;
        }
        #endregion

        #region 生成0-9随机数
        /// <summary>
        /// 生成0-9随机数
        /// </summary>
        /// <param name="codeNum">生成长度</param>
        /// <returns></returns>
        public static string RndNum(int codeNum)
        {
            StringBuilder sb = new StringBuilder(codeNum);
            Random rand = new Random();
            for (int i = 1; i < codeNum + 1; i++)
            {
                int t = rand.Next(9);
                sb.AppendFormat("{0}", t);
            }
            return sb.ToString();

        }
        #endregion

        #region 删除最后一个字符之后的字符
        /// <summary>
        /// 删除最后结尾的一个逗号
        /// </summary>
        public static string DelLastComma(string str)
        {
            return str.Substring(0, str.LastIndexOf(","));
        }
        /// <summary>
        /// 删除最后结尾的指定字符后的字符
        /// </summary>
        public static string DelLastChar(string str, string strchar)
        {
            return str.Substring(0, str.LastIndexOf(strchar));
        }
        /// <summary>
        /// 删除最后结尾的长度
        /// </summary>
        /// <param name="str"></param>
        /// <param name="Length"></param>
        /// <returns></returns>
        public static string DelLastLength(string str, int Length)
        {
            if (string.IsNullOrEmpty(str))
                return "";
            str = str.Substring(0, str.Length - Length);
            return str;
        }
        #endregion
    }


    /// <summary>
    /// Cookie帮助类
    /// </summary>
    public class CookieHelper
    {
        /// <summary>
        /// 写cookie值
        /// </summary>
        /// <param name="strName">名称</param>
        /// <param name="strValue">值</param>
        public static void WriteCookie(string strName, string strValue)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[strName];
            if (cookie == null)
            {
                cookie = new HttpCookie(strName);
            }
            cookie.Value = strValue;
            HttpContext.Current.Response.AppendCookie(cookie);

        }
        /// <summary>
        /// 写cookie值
        /// </summary>
        /// <param name="strName">名称</param>
        /// <param name="strValue">值</param>
        /// <param name="strValue">过期时间(分钟)</param>
        public static void WriteCookie(string strName, string strValue, int expires)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[strName];
            if (cookie == null)
            {
                cookie = new HttpCookie(strName);
            }
            cookie.Value = strValue;
            cookie.Expires = DateTime.Now.AddMinutes(expires);
            HttpContext.Current.Response.AppendCookie(cookie);

        }

        /// <summary>
        /// 读cookie值
        /// </summary>
        /// <param name="strName">名称</param>
        /// <returns>cookie值</returns>
        public static string GetCookie(string strName)
        {
            if (HttpContext.Current.Request.Cookies[strName] != null)
            {
                return HttpContext.Current.Request.Cookies[strName].Value.ToString();
            }
            return "";
        }

        /// <summary>
        /// Get cookie expiry date that was set in the cookie value 
        /// </summary>
        /// <param name="cookie"></param>
        /// <returns></returns>
        public static DateTime GetExpirationDate(HttpCookie cookie)
        {
            if (String.IsNullOrEmpty(cookie.Value))
            {
                return DateTime.MinValue;
            }
            string strDateTime = cookie.Value.Substring(cookie.Value.IndexOf("|") + 1);
            return Convert.ToDateTime(strDateTime);
        }

        /// <summary>
        /// Set cookie value using the token and the expiry date
        /// </summary>
        /// <param name="value"></param>
        /// <param name="minutes"></param>
        /// <returns></returns>
        public static string BuildCookueValue(string value, int minutes)
        {
            return String.Format("{0}|{1}", value, DateTime.Now.AddMinutes(minutes).ToString());
        }

        /// <summary>
        /// Reads cookie value from the cookie
        /// </summary>
        /// <param name="cookie"></param>
        /// <returns></returns>
        public static string GetCookieValue(HttpCookie cookie)
        {
            if (String.IsNullOrEmpty(cookie.Value))
            {
                return cookie.Value;
            }
            return cookie.Value.Substring(0, cookie.Value.IndexOf("|"));
        }
    }

    /// <summary>
    /// 加密与解密
    /// </summary>
    public class Encryption
    {
        private static string encryptKey = "4h!@w$rng,i#$@x1%)5^3(7*5P31/Ee0";

        //默认密钥向量
        private static byte[] Keys = { 0x41, 0x72, 0x65, 0x79, 0x6F, 0x75, 0x6D, 0x79, 0x53, 0x6E, 0x6F, 0x77, 0x6D, 0x61, 0x6E, 0x3F };
        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="encryptString"></param>
        /// <returns></returns>
        public static string Encrypt(string encryptString)
        {
            if (string.IsNullOrEmpty(encryptString))
                return string.Empty;
            RijndaelManaged rijndaelProvider = new RijndaelManaged();
            rijndaelProvider.Key = Encoding.UTF8.GetBytes(encryptKey.Substring(0, 32));
            rijndaelProvider.IV = Keys;
            ICryptoTransform rijndaelEncrypt = rijndaelProvider.CreateEncryptor();

            byte[] inputData = Encoding.UTF8.GetBytes(encryptString);
            byte[] encryptedData = rijndaelEncrypt.TransformFinalBlock(inputData, 0, inputData.Length);

            return Convert.ToBase64String(encryptedData);
        }
        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="decryptString"></param>
        /// <returns></returns>
        public static string Decrypt(string decryptString)
        {
            if (string.IsNullOrEmpty(decryptString))
                return string.Empty;
            try
            {
                RijndaelManaged rijndaelProvider = new RijndaelManaged();
                rijndaelProvider.Key = Encoding.UTF8.GetBytes(encryptKey.Substring(0, 32));
                rijndaelProvider.IV = Keys;
                ICryptoTransform rijndaelDecrypt = rijndaelProvider.CreateDecryptor();

                byte[] inputData = Convert.FromBase64String(decryptString);
                byte[] decryptedData = rijndaelDecrypt.TransformFinalBlock(inputData, 0, inputData.Length);

                return Encoding.UTF8.GetString(decryptedData);
            }
            catch
            {
                return "";
            }
        }
    }
    public class GenerateId
    {
        public static string GetGuidHash()
        {
            return Guid.NewGuid().ToString().GetHashCode().ToString("x");
        }

        /// <summary>
        /// 生成一个长整型，可以转成19字节长的字符串
        /// </summary>
        /// <returns>System.Int64.</returns>
        public static long GenerateLong()
        {
            byte[] buffer = Guid.NewGuid().ToByteArray();
            return BitConverter.ToInt64(buffer, 0);
        }

        /// <summary>
        /// 生成16个字节长度的数据与英文组合串
        /// </summary>
        public static string GenerateStr()
        {
            long i = 1;

            foreach (byte b in Guid.NewGuid().ToByteArray())
            {
                i *= ((int)b + 1);
            }

            return String.Format("{0:x}", i - DateTime.Now.Ticks);
        }

        /// <summary>
        /// 创建11位的英文与数字组合
        /// </summary>
        /// <returns>System.String.</returns>
        public static string ShortStr()
        {
            return Convert(GenerateLong());
        }

        /// <summary>
        /// 唯一订单号生成
        /// </summary>
        /// <returns></returns>
        public static string GenerateOrderNumber()
        {
            string strDateTimeNumber = DateTime.Now.ToString("yyyyMMddHHmmssffff");
            string strRandomResult = NextRandom(1000, 1).ToString("0000");

            return strDateTimeNumber + strRandomResult;
        }

        #region private

        /// <summary>
        /// 参考：msdn上的RNGCryptoServiceProvider例子
        /// </summary>
        /// <param name="numSeeds"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        private static int NextRandom(int numSeeds, int length)
        {
            // Create a byte array to hold the random value.
            byte[] randomNumber = new byte[length];
            // Create a new instance of the RNGCryptoServiceProvider.
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            // Fill the array with a random value.
            rng.GetBytes(randomNumber);
            // Convert the byte to an uint value to make the modulus operation easier.
            uint randomResult = 0x0;
            for (int i = 0; i < length; i++)
            {
                randomResult |= ((uint)randomNumber[i] << ((length - 1 - i) * 8));
            }

            return (int)(randomResult % numSeeds) + 1;
        }

        static string Seq = "s9LFkgy5RovixI1aOf8UhdY3r4DMplQZJXPqebE0WSjBn7wVzmN2Gc6THCAKut";

        /// <summary>
        /// 10进制转换为62进制
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private static string Convert(long id)
        {
            if (id < 62)
            {
                return Seq[(int)id].ToString();
            }
            int y = (int)(id % 62);
            long x = (long)(id / 62);

            return Convert(x) + Seq[y];
        }
        #endregion
    }


    /// <summary>
    /// http请求类
    /// </summary>
    public class HttpHelper
    {
        private HttpClient _httpClient;
        private string _baseIPAddress;

        /// <param name="ipaddress">请求的基础IP，例如：http://192.168.0.33:8080/ </param>
        public HttpHelper(string ipaddress = "")
        {
            this._baseIPAddress = ipaddress;
            _httpClient = new HttpClient { BaseAddress = new Uri(_baseIPAddress) };
        }

        /// <summary>
        /// 创建带用户信息的请求客户端
        /// </summary>
        /// <param name="userName">用户账号</param>
        /// <param name="pwd">用户密码，当WebApi端不要求密码验证时，可传空串</param>
        /// <param name="uriString">The URI string.</param>
        public HttpHelper(string userName, string pwd = "", string uriString = "")
            : this(uriString)
        {
            if (!string.IsNullOrEmpty(userName))
            {
                _httpClient.DefaultRequestHeaders.Authorization = CreateBasicCredentials(userName, pwd);
            }
        }

        /// <summary>
        /// Get请求数据
        ///   /// <para>最终以url参数的方式提交</para>
        /// <para>yubaolee 2016-3-3 重构与post同样异步调用</para>
        /// </summary>
        /// <param name="parameters">参数字典,可为空</param>
        /// <param name="requestUri">例如/api/Files/UploadFile</param>
        /// <returns></returns>
        public string Get(Dictionary<string, string> parameters, string requestUri)
        {
            if (parameters != null)
            {
                var strParam = string.Join("&", parameters.Select(o => o.Key + "=" + o.Value));
                requestUri = string.Concat(ConcatURL(requestUri), '?', strParam);
            }
            else
            {
                requestUri = ConcatURL(requestUri);
            }

            var result = _httpClient.GetStringAsync(requestUri);
            return result.Result;
        }

        /// <summary>
        /// Get请求数据
        /// <para>最终以url参数的方式提交</para>
        /// </summary>
        /// <param name="parameters">参数字典</param>
        /// <param name="requestUri">例如/api/Files/UploadFile</param>
        /// <returns>实体对象</returns>
        public T Get<T>(Dictionary<string, string> parameters, string requestUri) where T : class
        {
            string jsonString = Get(parameters, requestUri);
            if (string.IsNullOrEmpty(jsonString))
                return null;

            return JsonHelper.Instance.Deserialize<T>(jsonString);
        }

        /// <summary>
        /// 以json的方式Post数据 返回string类型
        /// <para>最终以json的方式放置在http体中</para>
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="requestUri">例如/api/Files/UploadFile</param>
        /// <returns></returns>
        public string Post(object entity, string requestUri)
        {
            string request = string.Empty;
            if (entity != null)
                request = JsonHelper.Instance.Serialize(entity);
            HttpContent httpContent = new StringContent(request);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return Post(requestUri, httpContent);
        }

        /// <summary>
        /// 提交字典类型的数据
        /// <para>最终以formurlencode的方式放置在http体中</para>
        /// <para>李玉宝于2016-07-20 19:01:59</para>
        /// </summary>
        /// <returns>System.String.</returns>
        public string PostDicObj(Dictionary<string, object> para, string requestUri)
        {
            Dictionary<string, string> temp = new Dictionary<string, string>();
            foreach (var item in para)
            {
                if (item.Value != null)
                {
                    if (item.Value.GetType().Name.ToLower() != "string")
                    {
                        temp.Add(item.Key, JsonHelper.Instance.Serialize(item.Value));
                    }
                    else
                    {
                        temp.Add(item.Key, item.Value.ToString());
                    }
                }
                else
                {
                    temp.Add(item.Key, "");
                }
            }

            return PostDic(temp, requestUri);
        }

        /// <summary>
        /// Post Dic数据
        /// <para>最终以formurlencode的方式放置在http体中</para>
        /// <para>李玉宝于2016-07-15 15:28:41</para>
        /// </summary>
        /// <returns>System.String.</returns>
        public string PostDic(Dictionary<string, string> temp, string requestUri)
        {
            HttpContent httpContent = new FormUrlEncodedContent(temp);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
            return Post(requestUri, httpContent);
        }

        public string PostByte(byte[] bytes, string requestUrl)
        {
            HttpContent content = new ByteArrayContent(bytes);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
            return Post(requestUrl, content);
        }

        private string Post(string requestUrl, HttpContent content)
        {
            var result = _httpClient.PostAsync(ConcatURL(requestUrl), content);
            return result.Result.Content.ReadAsStringAsync().Result;
        }

        /// <summary>
        /// 把请求的URL相对路径组合成绝对路径
        /// <para>李玉宝于2016-07-21 9:54:07</para>
        /// </summary>
        private string ConcatURL(string requestUrl)
        {
            return new Uri(_httpClient.BaseAddress, requestUrl).OriginalString;
        }

        private AuthenticationHeaderValue CreateBasicCredentials(string userName, string password)
        {
            string toEncode = userName + ":" + password;
            // The current HTTP specification says characters here are ISO-8859-1.
            // However, the draft specification for the next version of HTTP indicates this encoding is infrequently
            // used in practice and defines behavior only for ASCII.
            Encoding encoding = Encoding.GetEncoding("utf-8");
            byte[] toBase64 = encoding.GetBytes(toEncode);
            string parameter = Convert.ToBase64String(toBase64);

            return new AuthenticationHeaderValue("Basic", parameter);
        }
    }

    /// <summary>
    /// Json操作
    /// </summary>
    public static class Json
    {
        public static object ToJson(this string Json)
        {
            return Json == null ? null : JsonConvert.DeserializeObject(Json);
        }
        public static string ToJson(this object obj)
        {
            var timeConverter = new IsoDateTimeConverter { DateTimeFormat = "yyyy-MM-dd HH:mm:ss" };
            return JsonConvert.SerializeObject(obj, timeConverter);
        }
        public static string ToJson(this object obj, string datetimeformats)
        {
            var timeConverter = new IsoDateTimeConverter { DateTimeFormat = datetimeformats };
            return JsonConvert.SerializeObject(obj, timeConverter);
        }
        public static T ToObject<T>(this string Json)
        {
            return Json == null ? default(T) : JsonConvert.DeserializeObject<T>(Json);
        }
        public static List<T> ToList<T>(this string Json)
        {
            return Json == null ? null : JsonConvert.DeserializeObject<List<T>>(Json);
        }
        public static DataTable ToTable(this string Json)
        {
            return Json == null ? null : JsonConvert.DeserializeObject<DataTable>(Json);
        }
        public static JObject ToJObject(this string Json)
        {
            return Json == null ? JObject.Parse("{}") : JObject.Parse(Json.Replace("&nbsp;", ""));
        }
    }

    public class GuidConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType.IsAssignableFrom(typeof(Guid));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            Guid result = Guid.Empty;
            if (reader.Value == null) return result;
            Guid.TryParse(reader.Value.ToString(), out result);
            return result;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }
    }

    public class DecimalConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType.IsAssignableFrom(typeof(decimal));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            decimal result = 0;
            if (reader.Value == null) return result;
            decimal.TryParse(reader.Value.ToString(), out result);
            return result;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }
    }

    public class JsonHelper
    {
        private static JsonHelper _jsonHelper = new JsonHelper();
        public static JsonHelper Instance { get { return _jsonHelper; } }

        public string Serialize(object obj)
        {
            return JsonConvert.SerializeObject(obj, new IsoDateTimeConverter { DateTimeFormat = "yyyy-MM-dd HH:mm:ss" });
        }

        public string SerializeByConverter(object obj, params JsonConverter[] converters)
        {
            return JsonConvert.SerializeObject(obj, converters);
        }

        public T Deserialize<T>(string input)
        {
            return JsonConvert.DeserializeObject<T>(input);
        }

        public T DeserializeByConverter<T>(string input, params JsonConverter[] converter)
        {
            return JsonConvert.DeserializeObject<T>(input, converter);
        }

        public T DeserializeBySetting<T>(string input, JsonSerializerSettings settings)
        {
            return JsonConvert.DeserializeObject<T>(input, settings);
        }

        private object NullToEmpty(object obj)
        {
            return null;
        }
    }
    public class LogHelper
    {
        public static readonly ILog _log = LogManager.GetLogger("log4net");

        public static void Log(string message)
        {
            _log.Info(message);
        }

        public static void Debug(string message)
        {
            _log.Debug(message);
        }

        public static void Fatal(string message)
        {
            _log.Fatal(message);
        }

        public static void Warn(string message)
        {
            _log.Warn(message);
        }
    }

    public static class ObjectHelper
    {
        public static T CopyTo<T>(this object source) where T : class, new()
        {
            var result = new T();
            source.CopyTo(result);
            return result;
        }

        public static void CopyTo<T>(this object source, T target)
            where T : class, new()
        {
            if (source == null)
                return;

            if (target == null)
            {
                target = new T();
            }

            foreach (var property in target.GetType().GetProperties())
            {
                var propertyValue = source.GetType().GetProperty(property.Name).GetValue(source, null);
                if (propertyValue != null)
                {
                    if (propertyValue.GetType().IsClass)
                    {

                    }
                    target.GetType().InvokeMember(property.Name, BindingFlags.SetProperty, null, target, new object[] { propertyValue });
                }

            }

            foreach (var field in target.GetType().GetFields())
            {
                var fieldValue = source.GetType().GetField(field.Name).GetValue(source);
                if (fieldValue != null)
                {
                    target.GetType().InvokeMember(field.Name, BindingFlags.SetField, null, target, new object[] { fieldValue });
                }
            }
        }
    }
    /// <summary>
    /// 作为json返回数据
    /// </summary>
    public class Response
    {
        public bool Status = true;
        public string Message = "操作成功";
        public dynamic Result;
    }

    /// <summary>
    /// Session 帮助类
    /// </summary>
    public class SessionHelper
    {
        private static readonly string SessionUser = "SESSION_USER";
        public static void AddSessionUser<T>(T user)
        {
            HttpContext rq = HttpContext.Current;
            rq.Session[SessionUser] = user;
        }
        public static T GetSessionUser<T>()
        {
            try
            {
                HttpContext rq = HttpContext.Current;
                return (T)rq.Session[SessionUser];
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void Clear()
        {
            HttpContext rq = HttpContext.Current;
            rq.Session[SessionUser] = null;
        }
    }

    public class TreeItem<T>
    {
        public T Item { get; set; }
        public IEnumerable<TreeItem<T>> Children { get; set; }
    }

    /// <summary>
    /// URl帮助类
    /// </summary>
    public class UriUtil
    {
        /// <summary>
        /// 在URL后面追加参数
        /// </summary>
        /// <param name="url"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetAppendedQueryString(string url, string key, string value)
        {
            if (url.Contains("?"))
            {
                url = string.Format("{0}&{1}={2}", url, key, value);
            }
            else
            {
                url = string.Format("{0}?{1}={2}", url, key, value);
            }

            return url;
        }

        public static string RemoveParameter(string url, string key)
        {

            url = url.ToLower();
            key = key.ToLower();
            if (!url.Contains(key + "=")) return url;

            Uri uri = new Uri(url);
            NameValueCollection collection = HttpUtility.ParseQueryString(uri.Query);
            if (collection.Count == 0) return url;

            var val = collection[key];
            string fragmentToRemove = string.Format("{0}={1}", key, val);

            String result = url.ToLower().Replace("&" + fragmentToRemove, string.Empty).Replace("?" + fragmentToRemove, string.Empty);
            return result;
        }

        /// <summary>
        /// 根据URL的相对地址获取决定路径
        /// <para>eg: /Home/About ==>http://192.168.0.1/Home/About</para>
        /// </summary>
        /// <returns>System.String.</returns>
        public static string GetAbsolutePathForRelativePath(string relativePath)
        {
            HttpRequest Request = HttpContext.Current.Request;
            string returnUrl = string.Format("{0}{1}", Request.Url.AbsoluteUri.Replace(Request.Url.PathAndQuery, string.Empty), VirtualPathUtility.ToAbsolute(relativePath));
            return returnUrl;
        }
    }

    /// <summary>
    /// List转成Tree
    /// <para>李玉宝新增于2016-10-09 19:54:07</para>
    /// </summary>
    public static class GenericHelpers
    {
        /// <summary>
        /// Generates tree of items from item list
        /// </summary>
        /// 
        /// <typeparam name="T">Type of item in collection</typeparam>
        /// <typeparam name="K">Type of parent_id</typeparam>
        /// 
        /// <param name="collection">Collection of items</param>
        /// <param name="idSelector">Function extracting item's id</param>
        /// <param name="parentIdSelector">Function extracting item's parent_id</param>
        /// <param name="rootId">Root element id</param>
        /// 
        /// <returns>Tree of items</returns>
        public static IEnumerable<TreeItem<T>> GenerateTree<T, K>(
            this IEnumerable<T> collection,
            Func<T, K> idSelector,
            Func<T, K> parentIdSelector,
            K rootId = default(K))
        {
            foreach (var c in collection.Where(c => parentIdSelector(c).Equals(rootId)))
            {
                yield return new TreeItem<T>
                {
                    Item = c,
                    Children = collection.GenerateTree(idSelector, parentIdSelector, idSelector(c))
                };
            }
        }
    }
}
