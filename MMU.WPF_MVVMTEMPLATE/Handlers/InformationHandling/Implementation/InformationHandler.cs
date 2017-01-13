using $safeprojectname$.Models.Shell.Enumerations;

namespace $safeprojectname$.Handlers.InformationHandling.Implementation
{
    public class InformationHandler : IInformationHandler
    {
        private readonly IInformationHandlerConfiguration _informationHandlerConfiguration;

        public InformationHandler(IInformationHandlerConfiguration informationHandlerConfiguration)
        {
        _informationHandlerConfiguration = informationHandlerConfiguration;
        }

        public void HandleInformation(InformationType informationType, string message, int? displaySeconds)
        {
            foreach (var cb in _informationHandlerConfiguration.InformationCallbacks)
            {
                cb.Invoke(informationType, message, displaySeconds);
            }
        }
    }
}
