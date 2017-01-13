namespace $safeprojectname$.ViewModels.Shell.MainNavigation
{
    public interface IAmMainNavigationViewModel
    {
        string NavigationDescription { get; }

        int NavigationSequence { get; }
    }
}