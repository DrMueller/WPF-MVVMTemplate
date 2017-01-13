using System;
using System.Collections.Generic;
using $safeprojectname$.Infrastructure.Extensions.Helper;

namespace $safeprojectname$.Infrastructure.Extensions
{
    // The MIT License(MIT)
    // Copyright(c) 2014 Burtsev Alexey
    // http://stackoverflow.com/questions/129389/how-do-you-do-a-deep-copy-an-object-in-net-c-specifically/11308879#11308879 
    internal static class ObjectExtensions
    {
        #region Public/Internal Methods

        public static object DeepCopy(this object originalObject)
        {
            return DeepCopyHelper.DeepCopy(originalObject, new Dictionary<object, object>(new DeepCopyReferenceEqualityComparer()));
        }

        public static T DeepCopy<T>(this T original)
        {
            return (T)DeepCopy(original as Object);
        }

        #endregion
    }
}