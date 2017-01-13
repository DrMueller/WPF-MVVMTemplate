using System.Collections.Generic;
using System.Linq;

namespace $safeprojectname$.Models.Shell
{
    public class ViewModelParameterCollection
    {
        private static readonly ViewModelParameterCollection _empty = new ViewModelParameterCollection();

        public ViewModelParameterCollection(params ViewModelParameter[] parameters)
        {
            Parameters = parameters;
        }

        public bool HasValue
        {
            get
            {
                return this != Empty;
            }
        }

        public static ViewModelParameterCollection Empty
        {
            get
            {
                return _empty;
            }
        }

        public object this[string name]
        {
            get
            {
                return Parameters.Single(f => f.Name == name).Value;
            }
        }

        public IEnumerable<ViewModelParameter> Parameters { get; private set; }
    }
}
