using System;

namespace GymHub.WebClient.Infrastructure.Exceptions
{
    public class JavaScriptException : Exception
    {
        public JavaScriptException(string message)
            : base(message)
        {
        }
    }
}