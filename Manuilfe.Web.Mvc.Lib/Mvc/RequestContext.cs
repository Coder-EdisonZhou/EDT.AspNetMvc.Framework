using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Manulife.Web.Mvc.Lib.Mvc
{
    /// <summary>
    /// 将路由数据和请求上下文打包
    /// </summary>
    public class RequestContext
    {
        public HttpContext HttpContext { get; set; }

        public IDictionary<string, object> RouteData { get; set; }
    }
}
