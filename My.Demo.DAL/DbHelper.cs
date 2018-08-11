using My.Demo.Common;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.Demo.DAL
{
    /// <summary>
    /// 数据库对象封装
    /// </summary>
    public class DbHelper
    {
        /// <summary>
        /// SqlSugarClient对象(默认PubConstant.ConnectionString)
        /// </summary>
        public static SqlSugarClient DB => GetSqlSugarClient(PubConstant.ConnectionString);

        /// <summary>
        /// 实例出SqlSugarClient对象
        /// </summary>
        /// <param name="ConnectionString">使用PubConstant里面内容(默认为PubConstant.ConnectionString)</param>
        /// <returns></returns>
        public static SqlSugarClient GetSqlSugarClient(string ConnectionString = "")
        {
            //SqlSugarClient不能跨线程使用,保证一个线程new一个SqlSugarClient
            return new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = ConnectionString ?? PubConstant.ConnectionString,//必填, 数据库连接字符串
                DbType = DbType.MySql,//必填, 数据库类型
                IsAutoCloseConnection = true,//默认false, 时候知道关闭数据库连接, 设置为true无需使用using或者Close操作
                InitKeyType = InitKeyType.SystemTable,//默认SystemTable, 字段信息读取, 如：该属性是不是主键，是不是标识列等等信息
                IsShardSameThread = true//设为true相同线程是同一个SqlSugarClient
            });
        }
    }
}
