using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;
using System.Web.Http.ExceptionHandling;
using System.Web.Http.Cors;
using Swashbuckle.Application;
using Newtonsoft.Json;

namespace My.Demo.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //全局异常处理
            config.Services.Replace(typeof(IExceptionHandler), new ExceptionHandle());

            //跨域配置
            config.EnableCors(new EnableCorsAttribute("*", "*", "*"));

            // Web API 配置和服务
            // 将 Web API 配置为仅使用不记名令牌身份验证。
            //config.SuppressDefaultHostAuthentication();//取消调用SuppressDefaultHostAuthentication方法，恢复Host的默认身份认证
            //config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Web API 路由
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            
            //config.EnableAuth(GetAuthUser);

            var json = GlobalConfiguration.Configuration.Formatters.JsonFormatter;
            json.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Local;
            json.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss";
            json.SerializerSettings.DateFormatHandling = DateFormatHandling.MicrosoftDateFormat;
        }

        //private static AuthUserInfo GetAuthUser(string key)
        //{
        //    string user = RedisManager.GetCache(key, DataBase);

        //    if (!string.IsNullOrEmpty(user))
        //    {
        //        return JsonConvert.DeserializeObject<AuthUserInfo>(user);
        //    }
        //    return null;
        //}
    }
}
