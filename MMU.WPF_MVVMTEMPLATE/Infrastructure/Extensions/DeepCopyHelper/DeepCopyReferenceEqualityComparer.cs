using System.Collections.Generic;

namespace $safeprojectname$.Infrastructure.Extensions.Helper
{
    internal class DeepCopyReferenceEqualityComparer : EqualityComparer<object>
    {
        #region Public/Internal Methods

        public override bool Equals(object x, object y)
        {
            return ReferenceEquals(x, y);
        }

        public override int GetHashCode(object obj)
        {
            return obj?.GetHashCode() ?? 0;
        }

        #endregion
    }
}