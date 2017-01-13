using System;
using System.Collections.Generic;
using $safeprojectname$.ViewModels.Shell;

namespace $safeprojectname$.Handlers.NavigationHandling
{
    public interface INavigationHandlerConfiguration
    {
        IReadOnlyCollection<Action<ViewModelBase>> NavigationRequestedCallbacks { get; }

        void AddNavigationRequestedCallback(Action<ViewModelBase> navigationRequestedCallback);
    }
}