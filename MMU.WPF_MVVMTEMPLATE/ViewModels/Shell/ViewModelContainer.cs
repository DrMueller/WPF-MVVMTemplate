using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using $safeprojectname$.Commands;
using $safeprojectname$.Models.Shell;
using $safeprojectname$.Models.Shell.Enumerations;
using $safeprojectname$.Handlers.AppearanceHandling;
using $safeprojectname$.Handlers.ExceptionHandling;
using $safeprojectname$.Handlers.InformationHandling;
using $safeprojectname$.Handlers.NavigationHandling;
using $safeprojectname$.ViewModels.Shell.MainNavigation.Initialization;
using PropertyChanged;

namespace $safeprojectname$.ViewModels.Shell
{
    [ImplementPropertyChanged]
    public class ViewModelContainer
    {
        private readonly IAppearanceHandler _appearanceHandler;
        private readonly IExceptionHandler _exceptionHandler;
        private readonly IMainNavigationInitializer _mainNavigationInitializer;
        private AppearanceTheme _selectedAppearanceTheme;

        public ViewModelContainer(IAppearanceHandler appearanceHandler, IExceptionHandler exceptionHandler, IExceptionHandlerConfiguration exceptionHandlerConfiguration, IInformationHandlerConfiguration informationHandlerConfiguration, INavigationHandlerConfiguration navigationHandlerConfiguration, IMainNavigationInitializer mainNavigationInitializer)
        {
            _appearanceHandler = appearanceHandler;
            _exceptionHandler = exceptionHandler;
            _mainNavigationInitializer = mainNavigationInitializer;
            exceptionHandlerConfiguration.AddExceptionCallback(ShowExceptionMessageCallback);
            informationHandlerConfiguration.AddInformationCallback(ShowInformationMessageAsyncCallback);
            navigationHandlerConfiguration.AddNavigationRequestedCallback(NavigateToViewModelCallback);

            PublishInformation(InformationType.None, "Here could be your Text...");
            SelectedAppearanceTheme = _appearanceHandler.LoadPersistedAppearanceTheme();
            _mainNavigationInitializer.NavigateToMainEntryPoint();
        }

        public ParametredRelayCommand CloseCommand
        {
            get
            {
                return new ParametredRelayCommand(o =>
                {
                    var closable = (IClosable)o;
                    closable.Close();
                });
            }
        }

        public ICommand CloseMainNavigationPane
        {
            get
            {
                return new RelayCommand(() =>
                {
                    IsMainNavigationPaneOpen = false;
                });
            }
        }

        public ViewModelCommand CloseVmc => new ViewModelCommand("Close", CloseCommand);

        public ViewModelBase CurrentContent { get; private set; }

        public string InformationText { get; private set; }

        public bool IsMainNavigationPaneOpen { get; set; }

        public IEnumerable<ViewModelCommand> MainNavigationEntries
        {
            get
            {
                return _exceptionHandler.HandledFunction(() => _mainNavigationInitializer.GetOrderedMainNavigationEntries());
            }
        }

        public AppearanceTheme SelectedAppearanceTheme
        {
            get
            {
                return _selectedAppearanceTheme;
            }
            set
            {
                _appearanceHandler.SetAndPersistAppearanceTheme(value);
                _selectedAppearanceTheme = value;
            }
        }

        public InformationType SelectedInformationType { get; private set; }

        private void NavigateToViewModelCallback(ViewModelBase viewModelBase)
        {
            CurrentContent = viewModelBase;
        }

        private void PublishInformation(InformationType informationType, string message)
        {
            InformationText = message;
            SelectedInformationType = informationType;
        }

        private void ShowExceptionMessageCallback(Exception ex)
        {
            var text = ex.Message;
            PublishInformation(InformationType.Error, text);
        }

        private async void ShowInformationMessageAsyncCallback(InformationType informationType, string message, int? displaySeconds)
        {
            PublishInformation(informationType, message);
            if (displaySeconds.HasValue)
            {
                await Task.Delay(displaySeconds.Value * 1000);
                PublishInformation(InformationType.None, string.Empty);
            }
        }
    }
}