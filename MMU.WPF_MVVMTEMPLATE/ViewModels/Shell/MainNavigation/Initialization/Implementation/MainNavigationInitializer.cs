using System;
using System.Collections.Generic;
using System.Linq;
using $safeprojectname$.Commands;
using $safeprojectname$.Handlers.NavigationHandling;
using $safeprojectname$.Models.Shell;

namespace $safeprojectname$.ViewModels.Shell.MainNavigation.Initialization.Implementation
{
    public class MainNavigationInitializer : IMainNavigationInitializer
    {
        private readonly INavigationHandler _navigationHandler;
        private readonly ViewModelFactory _viewModelFactory;
        private IReadOnlyCollection<ViewModelCommand> _navigationViewModelCommands;

        public MainNavigationInitializer(INavigationHandler navigationHandler, ViewModelFactory viewModelFactory)
        {
            _navigationHandler = navigationHandler;
            _viewModelFactory = viewModelFactory;
        }

        public IReadOnlyCollection<ViewModelCommand> GetOrderedMainNavigationEntries()
        {
            AssureNavigationIsInitialized();
            return _navigationViewModelCommands;
        }

        public void NavigateToMainEntryPoint()
        {
            AssureNavigationIsInitialized();
            var mainEntry = _navigationViewModelCommands.FirstOrDefault();
            mainEntry?.Command.Execute(null);
        }

        private void AssureNavigationIsInitialized()
        {
            if (_navigationViewModelCommands == null)
            {
                _navigationViewModelCommands = CreateOrderedNavigationViewModels();
            }
        }

        private IReadOnlyCollection<ViewModelCommand> CreateOrderedNavigationViewModels()
        {
            var viewModelsDict = new Dictionary<int, ViewModelCommand>();
            var navigatableViewModels = GetNavigatableViewModels();

            foreach (var navigatableViewModel in navigatableViewModels)
            {
                var navigatableInterface = (IAmMainNavigationViewModel)navigatableViewModel;
                var vmc = new ViewModelCommand(navigatableInterface.NavigationDescription, new RelayCommand(() =>
                {
                    _navigationHandler.NavigateTo(navigatableViewModel);
                }));

                viewModelsDict.Add(navigatableInterface.NavigationSequence, vmc);
            }

            var result = viewModelsDict.OrderBy(f => f.Key).Select(f => f.Value).ToList();
            return result.AsReadOnly();
        }

        private IEnumerable<ViewModelBase> GetNavigatableViewModels()
        {
            var navigatableTypes = GetNavigatableViewModelTypes();
            var result = navigatableTypes.Select(f =>
            {
                var vm = _viewModelFactory.CreateViewModel(f, ViewModelParameterCollection.Empty);
                return vm;
            });

            return result;
        }

        private static IEnumerable<Type> GetNavigatableViewModelTypes()
        {
            var navigatableType = typeof(IAmMainNavigationViewModel);
            var viewModelbaseType = typeof(ViewModelBase);

            var result = navigatableType.Assembly.GetTypes().Where(f => navigatableType.IsAssignableFrom(f) && viewModelbaseType.IsAssignableFrom(f));
            return result.ToList();
        }
    }
}