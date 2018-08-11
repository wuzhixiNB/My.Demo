using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.Demo.Common
{
    public class PubConstant
    {
        private static string _connectionString { get; set; }

        /// <summary>
        /// 获取连接字符串
        /// </summary>
        public static string ConnectionString
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_connectionString))
                    _connectionString = ConfigurationManager.AppSettings["ConnectionString"];
                return _connectionString;
            }
        }

        /// <summary>
        /// 得到web.config/AppSettings节点里配置项的数据库连接字符串。
        /// </summary>
        /// <param name="configName"></param>
        /// <returns></returns>
        public static string GetConnectionString(string configName)
        {
            string connectionString = ConfigurationManager.AppSettings[configName];

            return connectionString;
        }
    }
}
