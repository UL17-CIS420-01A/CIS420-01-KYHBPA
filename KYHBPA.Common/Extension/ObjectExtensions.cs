namespace KYHBPA.Common
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
        public static string NullableToString(this object value) => value==null ? string.Empty : value.ToString();
    }
}
