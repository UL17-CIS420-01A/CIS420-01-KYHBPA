namespace KYHBPA.Common
{
    using System.ComponentModel;

    public static class EnumExtension
    {
        /// <summary>
        /// Gets the first [Description("")] Attribute of the enum.
        /// value.ToString() if there is none defined
        /// </summary>
        /// <param name="value">The enum value</param>
        /// <returns>The description</returns>

        public static string GetDescription(this System.Enum value)
        {
            var fieldInfo = value.GetType().GetField(value.ToString());
            var attributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if(attributes.Length>0)
            {
                return attributes[0].Description;
            }

            return value.ToString();
        }
    }
}
