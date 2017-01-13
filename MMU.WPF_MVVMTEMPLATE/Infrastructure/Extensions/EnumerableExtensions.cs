using System;
using System.Collections.Generic;

namespace $safeprojectname$.Infrastructure.Extensions
{
    internal static class EnumerableExtensions
    {
        #region Public/Internal Methods

        internal static void ForEach<T>(this IEnumerable<T> list, Action<T> action)
        {
            foreach (var entry in list)
            {
                action(entry);
            }
        }

        #endregion
    }
}