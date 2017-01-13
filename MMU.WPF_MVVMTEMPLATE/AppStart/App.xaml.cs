using System.Windows;
using Microsoft.Practices.Unity;
using $safeprojectname$.Infrastructure.Singletons;
using $safeprojectname$.Views.Shell;

namespace $safeprojectname$.AppStart
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        #region Protected Methods

        protected override void OnStartup(StartupEventArgs e)
        {
            Bootstrapper.Initialize();
            var viewContainer = UnityContainerInstance.Instance.Resolve<ViewContainer>();
            viewContainer.ShowDialog();
        }

        #endregion
    }
}