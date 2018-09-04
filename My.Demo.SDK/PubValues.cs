using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using My.Demo.SDK.Client;
using Newtonsoft.Json.Linq;
using My.Demo.Common;

namespace My.Demo.SDK
{
    public static class PubValues
    {
        private static string demoHost;
        public static string DemoHost
        {
            get
            {
                if (string.IsNullOrEmpty(demoHost))
                {
                    var host = ConfigurationManager.AppSettings["DemoHost"];
                    demoHost = host + "/api";
                }
                return demoHost;
            }
        }


         

        public static ResponseResult<T> DeserializeObject<T>(this string val)
        {
            try
            {
                JObject obj = JObject.Parse(val);
                if (!string.IsNullOrWhiteSpace(obj.Value<string>("Message")))
                {
                    return new ResponseResult<T>()
                    {
                        ErrorMessage = obj.Value<string>("Message")
                    };
                }
                if (!string.IsNullOrEmpty(val))
                    return JsonConvert.DeserializeObject<ResponseResult<T>>(val);
                return new ResponseResult<T>();
            }
            catch (Exception ex)
            {
                throw new ExceptionInfoBase("Sdk反序列化时候出错：" + val + "\n" + ex.Message, ex.Message);
            }
        }
    }
}
