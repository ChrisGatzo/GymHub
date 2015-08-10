using System.Web.Mvc;
using Elmah;
using GymHub.Infrastructure.Exceptions;

namespace GymHub.Controllers
{
    public class ErrorController : Controller
    {
        public void LogJavaScriptError(string message)
        {
            ErrorSignal
                .FromCurrentContext()
                .Raise(new JavaScriptException(message));
        }
	}
}