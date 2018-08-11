using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.Demo.Common
{
    /// <summary>
    /// API统一返回异常
    /// </summary>
    public abstract class CollectException : Exception
    {
        private List<ExceptionInfoBase> _exceptioinInfoList;

        public CollectException(List<ExceptionInfoBase> exceptioinInfo = null) : base()
        {
            _exceptioinInfoList = exceptioinInfo ?? new List<ExceptionInfoBase>();
        }

        public List<ExceptionInfoBase> ExceptioinInfoList
        {
            get { return _exceptioinInfoList; }
        }

        public void Add(ExceptionInfoBase exceptioinInfo)
        {
            if (exceptioinInfo != null)
                _exceptioinInfoList.Add(exceptioinInfo);
        }

        public void Add(List<ExceptionInfoBase> exceptioinInfoList)
        {
            if (exceptioinInfoList?.Any() ?? false)
                _exceptioinInfoList.AddRange(exceptioinInfoList);
        }
    }

    /// <summary>
    /// 异常基类(用于区分验证异常或未知异常)
    /// </summary>
    public class ExceptionInfoBase : Exception
    {
        private readonly string _errorCode;
        public ExceptionInfoBase(string msg, string errorCode = "") : base(msg ?? "未处理异常")
        {
            _errorCode = errorCode ?? "";
        }

        public string ErrorCode
        {
            get { return _errorCode; }
        }
    }
}
