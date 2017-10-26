namespace KYHBPA
{
    /// <summary>
    /// This is an extension class that adds additional 
    /// parsing functionality to the string class.
    /// </summary>
    public static class NullableStringExtensions
    {
        /// <summary>
        /// Parses a string to a nullable integer. If the value is
        /// null or invalid it returns a null value.
        /// </summary>
        /// <param name="value">String value</param>
        /// <returns>Int value or null</returns>
        public static int? ToNullableInt(this string value) => int.TryParse(value, out var result) ? result : (int?)null;

        /// <summary>
        /// Parses a string to a nullable boolean. If the value is 
        /// null or invalid it returns a null value.
        /// </summary>
        /// <param name="value">String value</param>
        /// <returns>True, false, or null</returns>
        public static bool? ToNullableBool(this string value) => bool.TryParse(value, out var result) ? result : (bool?)null;

        /// <summary>
        /// Parses a string to a nullable decimal. If the value is
        /// null or invalid it returns a null value.
        /// </summary>
        /// <param name="value">String value</param>
        /// <returns>Int value or null</returns>
        public static decimal? ToNullableDecimal(this string value) => decimal.TryParse(value, out var result) ? result : (decimal?)null;

        /// <summary>
        /// Parses a string to a nullable decimal. If the value is
        /// null or invalid it returns a null value.
        /// </summary>
        /// <param name="value">String value</param>
        /// <returns>Int value or null</returns>
        public static double? ToNullableDouble(this string value) => double.TryParse(value, out var result) ? result : (double?)null;
    }
}