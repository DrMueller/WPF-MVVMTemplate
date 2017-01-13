﻿using System;
using System.Threading.Tasks;

namespace $safeprojectname$.Handlers.ExceptionHandling.Implementation
{
    public class ExceptionHandler : IExceptionHandler
    {
        private readonly IExceptionLogger _logger;
        private readonly IExceptionHandlerConfiguration _exceptionHandlingConfiguration;

        public ExceptionHandler(IExceptionLogger logger, IExceptionHandlerConfiguration exceptionHandlerConfiguration)
        {
            _logger = logger;
            _exceptionHandlingConfiguration = exceptionHandlerConfiguration;
        }

        public void HandledAction(Action action)
        {
            try
            {
                action();
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        public async Task HandledActionAsync(Func<Task> action, Action finallyAction = null)
        {
            try
            {
                await action();
            }

            catch (OperationCanceledException)
            {
                // Nothing to do
            }

            catch (Exception ex)
            {
                HandleException(ex);
            }

            finally
            {
                finallyAction?.Invoke();
            }
        }

        public T HandledFunction<T>(Func<T> func)
        {
            try
            {
                return func();
            }
            catch (Exception ex)
            {
                HandleException(ex);
                return default(T);
            }
        }

        public async Task<T> HandledFunctionAsync<T>(Func<Task<T>> func)
        {
            try
            {
                var result = await func();
                return result;
            }
            catch (Exception ex)
            {
                HandleException(ex);
                return default(T);
            }
        }

        private void HandleException(Exception ex)
        {
            foreach (var cb in _exceptionHandlingConfiguration.ExceptionCallbacks)
            {
                cb.Invoke(ex);
            }

            _logger.LogException(ex);
        }
    }
}