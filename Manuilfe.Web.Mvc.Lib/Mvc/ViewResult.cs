using System;
using Manulife.Web.Mvc.Lib.View;

namespace Manulife.Web.Mvc.Lib.Mvc
{
    public class ViewResult : ActionResult
    {
        private object model;

        public ViewResult(object model)
        {
            this.model = model;
        }

        public override void Execute(RequestContext context)
        {
            var velocity = new VelocityHelper(string.Format("~/Views/{0}/", context.RouteData["controller"].ToString()));
            // 绑定实体model
            velocity.Put("model", this.model);
            // 显示具体html
            velocity.Display(string.Format("{0}.html", context.RouteData["action"].ToString()));
            // 设置响应头类型
            context.HttpContext.Response.ContentType = "text/html";
        }
    }
}
