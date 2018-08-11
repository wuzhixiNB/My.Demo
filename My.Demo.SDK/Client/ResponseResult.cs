using System;

namespace My.Demo.SDK.Client
{
    public class ResponseResult<T>
    {
        /// <summary>
        /// Gets or Sets Status
        /// </summary>
        public bool Status { get; set; }
        /// <summary>
        /// Gets or Sets Code
        /// </summary> 
        public string ErrorCode { get; set; }
        /// <summary>
        /// Gets or Sets Message
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// Gets or Sets Data
        /// </summary>
        public Object Data { get; set; }
    }
}