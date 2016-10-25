using Manulife.Web.Mvc.Lib.Routing;
using System;
using System.Collections.Generic;
using System.Web;

namespace Manulife.Web.Mvc.Lib.Mvc
{
    /// <summary>
    /// Route 的扩展方法所在类
    /// </summary>
    public static class RouteExtend
    {
        /// <summary>
        /// 指定MvcHandler来处理
        /// </summary>
        public static void MapRoute(this IList<Route> source, string urlTemplate, object defaults)
        {
            MapRoute(source, urlTemplate, defaults, routeData => new MvcHandler(routeData));
        }

        /// <summary>
        /// 通过指定实现了IHttpHandler的处理程序来处理
        /// </summary>
        public static void MapRoute(this IList<Route> source, string urlTemplate, object defaults, Func<IDictionary<string, object>, IHttpHandler> handler)
        {
            source.Add(new Route(urlTemplate, defaults, handler));
        }
    }
}
