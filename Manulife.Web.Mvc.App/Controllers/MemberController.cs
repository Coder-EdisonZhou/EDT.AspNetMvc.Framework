using Manulife.Web.Mvc.Lib.Mvc;
using Manulife.Web.Mvc.Models;
using System.Web;

namespace Manulife.Web.Mvc.Controllers
{
    public class MemberController : ControllerBase
    {
        public ActionResult Index(int id, string controller)
        {
            return new ContentResult(string.Format("<h1>Controller : {0}, Id : {1}</h1>", controller, id), "text/html");
        }

        public JsonResult GetList()
        {
            MemberStub memberService = new MemberStub();
            var memberList = memberService.GetMemberList();
            return new JsonResult(memberList);
        }
    }
}
