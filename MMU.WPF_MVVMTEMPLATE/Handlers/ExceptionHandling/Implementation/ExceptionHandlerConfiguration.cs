using System;
using System.Collections.Generic;

namespace $safeprojectname$.Handlers.ExceptionHandling.Implementation
{
    public class ExceptionHandlerConfiguration : IExceptionHandlerConfiguration
    {
        private readonly List<Action<Exception>> _exceptionCallbacks = new List<Action<Exception>>();

        public IReadOnlyCollection<Action<Exception>> ExceptionCallbacks
        {
            get
            {
                return _exceptionCallbacks;
            }
        }

        public void AddExceptionCallback(Action<Exception> exceptionCallback)
        {
            _exceptionCallbacks.Add(exceptionCallback);
        }
    }
}
