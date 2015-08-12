using System.Web.Mvc;
using Elmah;
using GymHub.WebClient.Infrastructure.Exceptions;

namespace GymHub.WebClient.Controllers
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