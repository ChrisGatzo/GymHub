using System;

namespace GymHub.Infrastructure.Exceptions
{
    public class JavaScriptException : Exception
    {
        public JavaScriptException(string message)
            : base(message)
        {
        }
    }
}