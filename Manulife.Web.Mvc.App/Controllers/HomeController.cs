using Manulife.Web.Mvc.Lib.Mvc;
using System;

namespace Manulife.Web.Mvc.Controllers
{
    public class HomeController : ControllerBase
    {
        public ActionResult Index(int id, string controller, string action)
        {
            return new ContentResult(string.Format("<h1>Controller : {0}, Action : {1}, Id : {2}</h1>", controller, action, id), "text/html");
        }

        public ActionResult View()
        {
            return new ViewResult(new { Id = 1, Name = "Edison Chou", Age = 27, Gender = true });
        }
    }
}
