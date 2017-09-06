namespace KYHBPA
{
    using System;
    using System.Text;

    /// <summary>
    /// This class is a utility class for encoding string values for transfer.
    /// </summary>
    /// <remarks>
    /// I.E. sending data to other pages using query strings.
    /// </remarks>
    public static class Base64StringExtensions
    {
        /// <summary>
        /// Encodes string in Base64
        /// </summary>
        /// <param name="value">string</param>
        /// <returns>string</returns>
        public static string ToBase64(this string value) => Convert.ToBase64String(Encoding.UTF8.GetBytes(value));

        /// <summary>
        /// Decodes Base64 string to UTF8
        /// </summary>
        /// <param name="value">string</param>
        /// <returns>string</returns>
        public static string FromBase64(this string value) => Encoding.UTF8.GetString(Convert.FromBase64String(value));
    }
}
