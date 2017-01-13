using System;
using System.Collections.Generic;

namespace $safeprojectname$.Handlers.ExceptionHandling
{
    public interface IExceptionHandlerConfiguration
    {
        void AddExceptionCallback(Action<Exception> exceptionCallback);

        IReadOnlyCollection<Action<Exception>> ExceptionCallbacks { get; }
    }
}