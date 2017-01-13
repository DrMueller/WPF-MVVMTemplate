using System.Windows;
using Microsoft.Practices.Unity;
using $safeprojectname$.Infrastructure.Singletons;
using $safeprojectname$.Models.Shell;
using $safeprojectname$.ViewModels.Shell;

namespace $safeprojectname$.Views.Shell
{
    /// <summary>
    /// Interaction logic for ViewContainer.xaml
    /// </summary>
    public partial class ViewContainer : Window, IClosable
    {
        public ViewContainer()
        {
            DataContext = UnityContainerInstance.Instance.Resolve<ViewModelContainer>();
            InitializeComponent();
        }
    }
}
