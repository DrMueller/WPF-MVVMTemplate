using $safeprojectname$.Models.Shell;
using $safeprojectname$.ViewModels.Shell;

namespace $safeprojectname$.Handlers.NavigationHandling
{
    public interface INavigationHandler
    {
        void NavigateTo<T>(ViewModelParameterCollection viewModelParameterCollection)
            where T : ViewModelBase;

        void NavigateTo(ViewModelBase target);
    }
}