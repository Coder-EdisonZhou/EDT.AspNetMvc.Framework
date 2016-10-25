using System;
using System.Web.Script.Serialization;

namespace Manulife.Web.Mvc.Lib.Mvc
{
    public class JsonResult : ActionResult
    {
        private object paraObj;

        public JsonResult(object paraObj)
        {
            this.paraObj = paraObj;
        }

        public override void Execute(RequestContext context)
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();
            var json = jss.Serialize(paraObj);
            context.HttpContext.Response.Write(json);
            context.HttpContext.Response.ContentType = "application/json";
        }
    }
}
