using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Drawing.Image;

namespace KYHBPA
{
    public static class ImageExtensions
    {
        public static byte[] ToByteArray(this Image image)
        {
            MemoryStream ms = new MemoryStream();
            image.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray();
        }

        public static Image ToImage(this IEnumerable<byte> bytes)
        {
            MemoryStream ms = new MemoryStream(bytes.ToArray());
            Image returnImage = FromStream(ms);
            return returnImage;
        }

        public static Image ToImage(this Stream inputStream, bool useEmbeddedColorManagement = true, bool validateImageData = true)
        {
            Image result = null;
            try
            {
                result = FromStream(stream: inputStream, useEmbeddedColorManagement: useEmbeddedColorManagement, validateImageData: validateImageData);
            }
            catch (Exception e)
            {
                // Log exception
            }
            return result;
        }

        public static byte[] ToByteArray(this Stream inputStream)
        {
            return inputStream?.ToImage()?.ToByteArray();
        }
    }
}
