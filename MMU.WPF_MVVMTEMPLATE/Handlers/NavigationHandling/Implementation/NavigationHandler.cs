using $safeprojectname$.Infrastructure.Extensions;
using $safeprojectname$.Models.Shell;
using $safeprojectname$.ViewModels.Shell;

namespace $safeprojectname$.Handlers.NavigationHandling.Implementation
{
    public class NavigationHandler : INavigationHandler
    {
        private readonly INavigationHandlerConfiguration _navigationHandlerConfiguration;
        private readonly ViewModelFactory _viewModelFactory;

        public NavigationHandler(INavigationHandlerConfiguration navigationHandlerConfiguration, ViewModelFactory viewModelFactory)
        {
            _navigationHandlerConfiguration = navigationHandlerConfiguration;
            _viewModelFactory = viewModelFactory;
        }

        public void NavigateTo<T>(ViewModelParameterCollection viewModelParameterCollection)
            where T : ViewModelBase
        {
            var targetViewModel = _viewModelFactory.CreateViewModel<T>(viewModelParameterCollection);
            _navigationHandlerConfiguration.NavigationRequestedCallbacks.ForEach(f => f.Invoke(targetViewModel));
        }

        public void NavigateTo(ViewModelBase target)
        {
            _navigationHandlerConfiguration.NavigationRequestedCallbacks.ForEach(f => f.Invoke(target));
        }
    }
}