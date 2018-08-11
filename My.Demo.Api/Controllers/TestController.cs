using My.Demo.Common;
using My.Demo.EntityModel;
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
            return new aaaa() { a = 1, e = "weew" }.Success();
        }
    }
}