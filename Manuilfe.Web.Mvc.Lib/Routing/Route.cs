using System;
using System.Collections.Generic;
using System.Web;

namespace Manulife.Web.Mvc.Lib.Routing
{
    /// <summary>
    /// 路由对象 ： 路由规则
    /// </summary>
    public class Route
    {
        public Route(string url, object defaults, Func<IDictionary<string, object>, IHttpHandler> handler)
        {
            UrlTemplate = url;

            Defaults = new Dictionary<string, object>();
            var defaultProperties = defaults.GetType().GetProperties();
            foreach (var item in defaultProperties)
            {
                Defaults.Add(item.Name, item.GetValue(defaults));
            }

            GetRouteHandler = handler;
        }

        /// <summary>
        /// 路由模板
        /// </summary>
        public string UrlTemplate
        {
            get;
            set;
        }

        /// <summary>
        /// 默认路由规则
        /// new { controller = "Home", action = "Index" }
        /// </summary>
        public IDictionary<string, object> Defaults
        {
            get;
            set;
        }

        /// <summary>
        /// HttpHandler
        /// </summary>
        public Func<IDictionary<string, object>, IHttpHandler> GetRouteHandler
        {
            get;
            set;
        }

        /// <summary>
        /// 让该路由规则主动匹配一个Url
        /// </summary>
        /// <param name="requestUrl"></param>
        public bool MatchUrl(string requestUrl, out IDictionary<string, object> routeData)
        {
            // this.UrlTemplate and requestUrl
            routeData = new Dictionary<string, object>();
            foreach (var item in Defaults)
            {
                // 为路由数据中装入默认值
                routeData.Add(item.Key, item.Value);
            }

            var requestUrlItems = requestUrl.Split('/');
            var urlTemplateItems = UrlTemplate.Split('/');

            // 1.判断格式是否匹配
            if (requestUrlItems.Length != urlTemplateItems.Length)
            {
                return false;
            }

            // 2.判断参数是否匹配
            for (int i = 0; i < requestUrlItems.Length; i++)
            {
                var urlTemplateItem = urlTemplateItems[i]; // {controllerName}
                var requestUrlItem = requestUrlItems[i]; // controllerName
                if (urlTemplateItem.StartsWith("{") && urlTemplateItem.EndsWith("}"))
                {
                    // 此时模板中是一个占位符变量
                    var key = urlTemplateItem.Trim("{}".ToCharArray());
                    if (routeData.ContainsKey(key) && !string.IsNullOrEmpty(requestUrlItem))
                    {
                        // 字典中存在该键值对则替换
                        routeData[key] = requestUrlItem;
                    }
                }
                else
                {
                    // 不是占位符则必须强匹配
                    if (!urlTemplateItem.Equals(requestUrlItem, StringComparison.InvariantCultureIgnoreCase))
                    {
                        // 防止外部调用方拿到假数据
                        routeData.Clear();
                        // 该位置没有匹配成功
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
