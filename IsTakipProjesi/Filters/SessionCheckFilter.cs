using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace IsTakipProjesi.Filters
{
    public class SessionCheckFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext filterContext) 
        {
            var skipSessionCheck = filterContext.ActionDescriptor.EndpointMetadata
                .Any(em => em.GetType() == typeof(SkipSessionCheckAttribute));

            if (skipSessionCheck )
            {
                return;
            }

            var session = filterContext.HttpContext.Session;
            var userId = session.GetString("UserID");

            if(string.IsNullOrEmpty(userId) )
            {
                filterContext.Result = new RedirectToActionResult("Index", "Auth",null);
            }
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            //İşlem sonunda bir işlem olmayacak, direkt yönlendirme mevcut.
        }
    }
}
