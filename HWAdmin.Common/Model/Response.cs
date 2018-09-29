namespace HWAdmin.Common.Model
{
    /// <summary>
    /// 返回信息
    /// </summary>
    public class Response : IResponse
    {
        /// <summary>
        /// 操作消息【当Status不为 200时，显示详细的错误信息】
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// 操作状态码，200为正常
        /// </summary>
        public int Code { get; set; }
        /// <summary>
        /// 其他参数
        /// </summary>
        public decimal Option { get; set; }

        public bool Status { get; set; }

        public Response()
        {
            Code = 200;
            Message = "操作成功";
        }
    }

    /// <summary>
    /// WEBAPI通用返回泛型基类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Response<T> : Response
    {
        /// <summary>
        /// 回传的结果
        /// </summary>
        public T Result { get; set; }

    }


    /// <summary>
    /// 开启日志记录返回JsonResult 时 数据需要继承自 IResponse
    /// </summary>
    public interface IResponse
    {
        bool Status { get; set; }
        string Message { get; set; }
    }
}
