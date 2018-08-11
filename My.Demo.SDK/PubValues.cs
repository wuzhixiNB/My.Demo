using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using My.Demo.SDK.Client;

namespace My.Demo.SDK
{
    public static class PubValues
    {
        private static string warehouseHost;
        public static string WarehouseHost
        {
            get
            {
                if (string.IsNullOrEmpty(warehouseHost))
                {
                    var host = ConfigurationManager.AppSettings["DemoHost"];
                    warehouseHost = host + "/api";
                }
                return warehouseHost;
            }
        }


         

        public static ResponseResult<T> DeserializeObject<T>(this string val)
        {
            if (!string.IsNullOrEmpty(val))
                return JsonConvert.DeserializeObject<ResponseResult<T>>(val);
            return new ResponseResult<T>();
        }
    }
}
