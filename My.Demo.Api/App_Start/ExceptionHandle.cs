using My.Demo.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.ExceptionHandling;
using System.Web.Http.Results;

namespace My.Demo.Api
{
    /// <summary>
    /// 全局异常处理
    /// </summary>
    public class ExceptionHandle : IExceptionHandler
    {
        /// <summary>
        /// 实现接口-异步处理
        /// </summary>
        /// <param name="context"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task HandleAsync(ExceptionHandlerContext context, CancellationToken cancellationToken)
        {
            this.Handle(context);//调用异常处理
            return Task.FromResult(true);
        }

        /// <summary>
        /// 处理异常信息
        /// </summary>
        /// <param name="context"></param>
        private void Handle(ExceptionHandlerContext context)
        {
            var exception = context.Exception.GetBaseException();//通过context得到Exception
            object errAry = null;
            var errBase = exception as ExceptionInfoBase;
            if (exception is ExceptionInfoBase)//验证异常
            {
                errAry = new List<object> { new {
                    ((ExceptionInfoBase)exception).ErrorCode,
                    ((ExceptionInfoBase)exception).Message }
                };
            }
            else if (exception is CollectException)//集合异常
            {
                errAry = ((CollectException)exception).ExceptioinInfoList.Select(x => new
                {
                    x.ErrorCode,
                    x.Message
                });
            }
            else//未知异常
            {
                var ErrorCode = "UnKnown";
                errAry = new List<object> { new { ErrorCode, exception.Message } };
            }

            var result = new
            {
                Status = false,
                Error = errAry
            };

            context.Result = new ResponseMessageResult(context.Request.CreateResponse(HttpStatusCode.OK, result));
        }
    }
}