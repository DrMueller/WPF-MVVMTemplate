using Microsoft.Practices.Unity;
using $safeprojectname$.Infrastructure.Singletons;

namespace $safeprojectname$.AppStart
{
    internal static class Bootstrapper
    {
        internal static void Initialize()
        {
            InitializeUnityContainer();
            ViewModelMappingInitializer.Initialize();
        }

        private static void InitializeContainerTypes(IUnityContainer uc)
        {
            uc.RegisterType<ViewModels.Shell.MainNavigation.Initialization.IMainNavigationInitializer, ViewModels.Shell.MainNavigation.Initialization.Implementation.MainNavigationInitializer>();

            uc.RegisterType<Handlers.AppearanceHandling.IAppearanceHandler, Handlers.AppearanceHandling.Implementation.AppearanceHandler>();

            uc.RegisterType<Handlers.ExceptionHandling.IExceptionHandler, Handlers.ExceptionHandling.Implementation.ExceptionHandler>(new ContainerControlledLifetimeManager());
            uc.RegisterType<Handlers.ExceptionHandling.IExceptionHandlerConfiguration, Handlers.ExceptionHandling.Implementation.ExceptionHandlerConfiguration>(new ContainerControlledLifetimeManager());
            uc.RegisterType<Handlers.ExceptionHandling.IExceptionLogger, Handlers.ExceptionHandling.Implementation.ExceptionLogger>(new ContainerControlledLifetimeManager());

            uc.RegisterType<Handlers.InformationHandling.IInformationHandler, Handlers.InformationHandling.Implementation.InformationHandler>(new ContainerControlledLifetimeManager());
            uc.RegisterType<Handlers.InformationHandling.IInformationHandlerConfiguration, Handlers.InformationHandling.Implementation.InformationHandlerConfiguration>(new ContainerControlledLifetimeManager());

            uc.RegisterType<Handlers.NavigationHandling.INavigationHandler, Handlers.NavigationHandling.Implementation.NavigationHandler>(new ContainerControlledLifetimeManager());
            uc.RegisterType<Handlers.NavigationHandling.INavigationHandlerConfiguration, Handlers.NavigationHandling.Implementation.NavigationHandlerConfiguration>(new ContainerControlledLifetimeManager());
        }

        private static void InitializeUnityContainer()
        {
            var uc = new UnityContainer();
            InitializeContainerTypes(uc);
            ViewModelRegistering.RegisterViewModels(uc);
            UnityContainerInstance.Initialize(uc);
        }
    }
}