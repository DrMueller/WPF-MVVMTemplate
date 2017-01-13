using System.Collections.Generic;

namespace $safeprojectname$.ViewModels.Shell.MainNavigation.Initialization
{
    public interface IMainNavigationInitializer
    {
        IReadOnlyCollection<ViewModelCommand> GetOrderedMainNavigationEntries();

        void NavigateToMainEntryPoint();
    }
}
