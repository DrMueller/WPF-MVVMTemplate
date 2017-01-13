using System;

namespace $safeprojectname$.Handlers.ExceptionHandling
{
    public interface IExceptionLogger
    {
        void LogException(Exception ex);
    }
}
