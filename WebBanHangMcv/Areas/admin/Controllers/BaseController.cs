using System.Web.Mvc;

namespace WebBanHangMcv.Areas.admin.Controllers
{
    public class BaseController : Controller
    {
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {

            var session = (string)Session["UserName"];
            //if (filterContext.ActionDescriptor.ControllerDescriptor.ControllerName == "login")
            //{
            //    strControlerCurrent = string.Empty;
            //}
            //else
            //{
            //    strControlerCurrent = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            //}

            if (session == null)
            {
                filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(new { Controller = "Login", Action = "Index" }));
            }

            base.OnActionExecuted(filterContext);
        }
    }
}