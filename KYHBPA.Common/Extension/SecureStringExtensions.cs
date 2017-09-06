namespace KYHBPA
{
    using System;
    using System.Runtime.InteropServices;
    using System.Security;

    public static class SecureStringExtensions
    {
        /// <summary>
        /// Stores string in unmanaged memory.
        /// </summary>
        /// <remarks>
        /// Reasons to use this: If the web server should crash, a dump file will be created 
        /// that contains all the data stored in memory. Storing a string in unmanaged memory will
        /// prevent* it from being written to that dump file.
        /// *Exception: if the web server should crash while that data is being used/accessed, it may be
        /// written to the dump file.
        /// </remarks>
        /// <param name="value">string value</param>
        /// <returns>SecureString</returns>
        public static SecureString ToSecureString(this string value)
        {
            if(string.IsNullOrEmpty(value))
            {
                return null;
            }

            var secureString = new SecureString();

            foreach(var character in value)
            {
                secureString.AppendChar(character);
            }

            return secureString;
        }

        /// <summary>
        /// Retrieves a string from unmanaged memory.
        /// </summary>
        /// <param name="value">SecureString value</param>
        /// <returns>string or string.Empty</returns>
        public static string FromSecureString(this SecureString value)
        {
            if(value==null)
            {
                return string.Empty;
            }

            IntPtr valuePtr = IntPtr.Zero;

            try
            {
                valuePtr=Marshal.SecureStringToGlobalAllocUnicode(value);

                return Marshal.PtrToStringUni(valuePtr);
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(valuePtr);
            }
        }
    }
}
