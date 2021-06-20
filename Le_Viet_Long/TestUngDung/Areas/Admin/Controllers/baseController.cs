using ModelEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using TestUngDung.Areas.Admin.Model;

namespace TestUngDung.Areas.Admin.Controllers
{
    public class baseController : Controller
    {
        // GET: Admin/base
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var session = (LoginModel)Session[constants.USER_SESSION];
            if (session == null)
            {
                filterContext.Result = new RedirectToRouteResult(new
                    RouteValueDictionary(new { controller = "Login", action = "Index", Areas = "Admin" }));
            }
            base.OnActionExecuted(filterContext);
        }

        protected void SetAlert(string message, string type)
        {
            TempData["AlertMessage"] = message;
            if (type == "success")
            {
                TempData["AlertType"] = "alert-success";
            }
            else if (type == "warning")
            {
                TempData["AlertType"] = "alert-warning";
            }
            else if (type == "error")
            {
                TempData["AlertType"] = "alert-danger";
            }

        }
    }
}