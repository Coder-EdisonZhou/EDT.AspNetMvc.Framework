using System.Collections.Generic;
using System.Web;

namespace Manulife.Web.Mvc.Lib.Mvc
{
    public class MvcHandler : IHttpHandler
    {
        private IDictionary<string, object> routeData;

        public MvcHandler(IDictionary<string, object> routeData)
        {
            this.routeData = routeData;
        }

        public void ProcessRequest(HttpContext context)
        {
            var controllerName = routeData["controller"].ToString();
            // 借助控制器工厂创建具体控制器实例
            IController controller = DefaultControllerFactory.CreateController(controllerName);
            // 确保有找到一个Controller处理请求
            if (controller == null)
            {
                // 404 Not Found!
                throw new HttpException(404, "Not Found");
            }
            // 封装请求
            var requestContext = new RequestContext { HttpContext = context, RouteData = routeData };
            // 开始执行
            var result = controller.Execute(requestContext);
            result.Execute(requestContext);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
