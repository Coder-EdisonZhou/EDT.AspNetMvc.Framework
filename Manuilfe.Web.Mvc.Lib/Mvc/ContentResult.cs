using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manulife.Web.Mvc.Lib.Mvc
{
    public class ContentResult : ActionResult
    {
        private string content;
        private string contentType;

        public ContentResult(string content, string contentType)
        {
            this.content = content;
            this.contentType = contentType;
        }

        public override void Execute(RequestContext context)
        {
            context.HttpContext.Response.Write(content);
            context.HttpContext.Response.ContentType = contentType;
        }
    }
}
