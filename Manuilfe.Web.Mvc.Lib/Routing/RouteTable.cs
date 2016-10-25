using System.Collections.Generic;

namespace Manulife.Web.Mvc.Lib.Routing
{
    /// <summary>
    /// 全局路由表 : 路由规则对象集合
    /// </summary>
    public static class RouteTable
    {
        public static IList<Route> Routes
        {
            get;
            set;
        }

        static RouteTable()
        {
            Routes = new List<Route>();
        }

        /// <summary>
        /// 根据请求的pathinfo解析路由数据
        /// </summary>
        public static Route MatchRoutes(string requestUrl, out IDictionary<string, object> dictRoutes)
        {
            dictRoutes = null;
            foreach (var route in RouteTable.Routes)
            {
                // 让当前遍历到的路由规则匹配当前请求的Url地址
                if (route.MatchUrl(requestUrl, out dictRoutes))
                {
                    return route;
                }
            }

            return null;
        }
    }
}
