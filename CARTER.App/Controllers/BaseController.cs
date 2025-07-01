using CARTER.App.Helpers.Extensions;
using CARTER.Models.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CARTER.App.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var sessions = context.HttpContext.Session.GetString("Token");
            if (sessions == null)
            {
                context.Result = new RedirectToActionResult("Index", "Login", null);
                if (Request.IsAjaxRequest())
                {
                    throw new AjaxException("Test");
                }
            }
            base.OnActionExecuting(context);
        }

    }

}
