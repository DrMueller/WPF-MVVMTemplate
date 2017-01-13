using $safeprojectname$.Models.Shell.Enumerations;

namespace $safeprojectname$.Handlers.InformationHandling
{
    public interface IInformationHandler
    {
        void HandleInformation(InformationType informationType, string message, int? displaySeconds = null);
    }
}
