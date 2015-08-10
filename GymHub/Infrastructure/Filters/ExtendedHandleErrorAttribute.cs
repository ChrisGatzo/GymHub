using System.Web;
using System.Web.Mvc;
using Elmah;
using GymHub.Resources;

namespace GymHub.Infrastructure.Filters
{
    public class ExtendedHandleErrorAttribute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            if (filterContext.ExceptionHandled /*|| !filterContext.HttpContext.IsCustomErrorEnabled*/)
            {
                return;
            }

            if (new HttpException(null, filterContext.Exception).GetHttpCode() != 500)
            {
                return;
            }

            if (!ExceptionType.IsInstanceOfType(filterContext.Exception))
            {
                return;
            }

            var controllerName = (string)filterContext.RouteData.Values["controller"];
            var actionName = (string)filterContext.RouteData.Values["action"];
            var model = new HandleErrorInfo(filterContext.Exception, controllerName, actionName);

            // if the request is AJAX return JSON else view.
            if (filterContext.HttpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                var stackTrace = "";
                if (HttpContext.Current.IsDebuggingEnabled)
                {
                    stackTrace = model.Exception.StackTrace;
                }

                filterContext.Result = new JsonResult
                {
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                    Data = new
                    {
                        error = true,
                        message = Strings.UnexpectedErrorOccurred,
                        stackTrace = stackTrace
                    }
                };
            }
            else
            {             
                filterContext.Result = new ViewResult
                {
                    ViewName = View,
                    MasterName = Master,
                    ViewData = new ViewDataDictionary<HandleErrorInfo>(model),
                    TempData = filterContext.Controller.TempData
                };
            }

            filterContext.ExceptionHandled = true;
            filterContext.HttpContext.Response.Clear();
            filterContext.HttpContext.Response.StatusCode = 500;

            filterContext.HttpContext.Response.TrySkipIisCustomErrors = true;

            ErrorSignal
             .FromCurrentContext()
             .Raise(filterContext.Exception);

        }
    }
}