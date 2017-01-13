using System;
using System.Collections.Generic;
using $safeprojectname$.Models.Shell.Enumerations;

namespace $safeprojectname$.Handlers.InformationHandling.Implementation
{
    public class InformationHandlerConfiguration : IInformationHandlerConfiguration
    {
        private List<Action<InformationType, string, int?>> _informationCallbacks = new List<Action<InformationType, string, int?>>();

        public void AddInformationCallback(Action<InformationType, string, int?> informationCallback)
        {
            _informationCallbacks.Add(informationCallback);
        }

        public IReadOnlyCollection<Action<InformationType, string, int?>> InformationCallbacks
        {
            get
            {
                return _informationCallbacks;
            }
        }
    }
}
