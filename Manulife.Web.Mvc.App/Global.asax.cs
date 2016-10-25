using System;
using Manulife.Web.Mvc.Lib.Routing;
using Manulife.Web.Mvc.Lib.Mvc;

namespace Manulife.Web.Mvc
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            // 注册路由规则1
            RouteTable.Routes.MapRoute(
                urlTemplate: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index" }
                );
            // 注册路由规则2
            RouteTable.Routes.MapRoute(
                urlTemplate: "{controller}/{action}",
                defaults: new { controller = "Home", action = "Index" }
                );
            // 注册路由规则3
            RouteTable.Routes.MapRoute(
                urlTemplate: "{controller}",
                defaults: new { controller = "Home", action = "Index" }
                );
        }

    }
}