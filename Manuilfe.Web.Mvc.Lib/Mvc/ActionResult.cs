using System;

namespace Manulife.Web.Mvc.Lib.Mvc
{
    /// <summary>
    /// Action统一的返回类型
    /// </summary>
    public abstract class ActionResult
    {
        public abstract void Execute(RequestContext context);
    }
}
