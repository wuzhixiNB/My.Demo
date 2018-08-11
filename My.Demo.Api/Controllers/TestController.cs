using My.Demo.SDK.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace My.Demo.Api.Controllers
{
    public class TestController : ApiController
    {
        // GET: Test
        [HttpGet]
        public ResponseResult<bool> Index()
        {
            return new ResponseResult<bool>() { Data = true };
        }

        /// <summary>
        /// 测试文件
        /// </summary>
        /// <param name="aa">cs模型</param>
        /// <returns></returns>
        [HttpPost]
        public ResponseResult<aaaa> adada(aaaa aa)
        {
            return new ResponseResult<aaaa>() { Data = new aaaa() { a =1, e = "weew" } };
        }
    }

    /// <summary>
    /// 测试模型
    /// </summary>
    public class aaaa
    {
        /// <summary>
        /// 测试参数23
        /// </summary>
        public int a { get; set; }

        /// <summary>
        /// 测试参数1
        /// </summary>
        public string e { get; set; }
    }
}