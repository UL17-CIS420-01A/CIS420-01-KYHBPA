using System.IO;
using Newtonsoft.Json;

namespace KYHBPA
{
    /// <summary>
    /// Object Extension Class
    /// </summary>
    public static class ObjectExtensions
    {
        /// <summary>
        /// Converts an object to String Even if Null
        /// </summary>
        /// <param name="value">Input value</param>
        /// <returns>String output, even if value is null</returns>
        public static string NullableToString<T>(this T value) => value?.ToString() ?? string.Empty;

        /// <summary>
        /// Determines whether the specified object instances are considered equal.
        /// </summary>
        /// <param name="objA">The first object to compare.</param>
        /// <param name="objB">The second object to compare.</param>
        /// <returns>
        /// true if the objects are considered equal; otherwise, false.
        /// If both objA and objB are null, the method returns true.
        /// </returns>
        public static bool Is(this object objA, object objB) => Equals(objA, objB);

        /// <summary>
        /// Determines whether the specified object instance is considered equal to null.
        /// </summary>
        /// <param name="value">object</param>
        /// <returns>
        /// true if the objects are considered equal; otherwise, false.
        /// If both objA and objB are null, the method returns true.
        /// </returns>
        public static bool IsNull<T>(this T value) => value.Is(null);
    }
}
