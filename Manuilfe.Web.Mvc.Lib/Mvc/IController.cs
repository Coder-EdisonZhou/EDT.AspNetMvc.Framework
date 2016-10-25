using System.Web;

namespace Manulife.Web.Mvc.Lib.Mvc
{
    /// <summary>
    /// 约束所有Controller所具备的处理请求能力
    /// </summary>
    public interface IController
    {
        ActionResult Execute(RequestContext context);
    }
}
