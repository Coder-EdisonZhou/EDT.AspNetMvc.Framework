using System;
using System.Collections.Generic;
using System.Web;

namespace Manulife.Web.Mvc.Lib.Routing
{
    /// <summary>
    /// 解析请求中的路由数据，并分发请求到Handler
    /// </summary>
    public class UrlRoutingModule : IHttpModule
    {
        public void Init(HttpApplication application)
        {
            // 注册ASP.NET请求处理管道的第七个事件
            application.PostResolveRequestCache += Application_PostResolveRequestCache;
        }

        // 假设请求 http://www.edisonchou.cn/home/index
        private void Application_PostResolveRequestCache(object sender, EventArgs e)
        {
            var application = sender as HttpApplication;
            var context = application.Context;
            // 根据全局路由表解析当前请求的路径
            var requestUrl = context.Request.AppRelativeCurrentExecutionFilePath.Substring(2);
            // 遍历全局路由表中的路由规则解析数据
            IDictionary<string, object> routeData;
            var route = RouteTable.MatchRoutes(requestUrl, out routeData);
            if (route == null)
            {
                // 404 Not Found
                throw new HttpException(404, "Not Found!");
            }
            // 获取处理请求的Handler处理程序
            if (!routeData.ContainsKey("controller"))
            {
                // 404 Not Found
                throw new HttpException(404, "Not Found!");
            }
            var handler = route.GetRouteHandler(routeData);
            // 为当前请求指定Handler处理程序
            context.RemapHandler(handler);
        }

        public void Dispose()
        {
            this.Dispose();
        }
    }
}
