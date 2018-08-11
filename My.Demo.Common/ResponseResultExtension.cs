using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.Demo.Common
{
    public class ResponseResult<T>
    {
        /// <summary>
        /// 请求状态  必须
        /// </summary>
        public bool Status { get; set; }
        /// <summary>
        /// 错误码 非必须
        /// </summary>
        public string ErrorCode { get; set; }
        /// <summary>
        /// 错误消息 非必须
        /// </summary>
        public string ErrorMessage { get; set; }
        /// <summary>
        /// 返回数据，非必须
        /// </summary>
        public T Data { get; set; }

    }

    /// <summary>
    /// 响应对象公共方法
    /// </summary>
    public static class ResponseResultExtension
    {
        /// <summary>
        /// 响应成功
        /// </summary>
        /// <param name="data"></param>
        /// <param name="message"></param>
        /// <param name="code"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static ResponseResult<T> Success<T>(this T data, string message = null, string code = null)
        {
            var rep = new ResponseResult<T>
            {
                Status = true,
                Data = data,

            };
            if (message != null)
                rep.ErrorMessage = message;
            if (code != null)
                rep.ErrorCode = code;
            return rep;
        }
        /// <summary>
        /// 响应异常
        /// </summary>
        /// <param name="data"></param>
        /// <param name="message"></param>
        /// <param name="code"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static ResponseResult<T> Error<T>(this T data, string message = null, string code = null)
        {
            var rep = new ResponseResult<T>
            {
                Status = false,
            };
            if (message != null)
                rep.ErrorMessage = message;
            if (code != null)
                rep.ErrorCode = code;
            if (message != null)
                rep.ErrorMessage = message;
            if (data != null)
                rep.Data = data;
            return rep;
        }

    }
}
