using System;
using System.Collections.Generic;
using $safeprojectname$.Models.Shell.Enumerations;

namespace $safeprojectname$.Handlers.InformationHandling
{
    public interface IInformationHandlerConfiguration
{
    void AddInformationCallback(Action<InformationType, string, int?> informationCallback);

    IReadOnlyCollection<Action<InformationType, string, int?>> InformationCallbacks { get; }
}
}
