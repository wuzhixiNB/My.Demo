using System;

namespace My.Demo.SDK.Client
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
}