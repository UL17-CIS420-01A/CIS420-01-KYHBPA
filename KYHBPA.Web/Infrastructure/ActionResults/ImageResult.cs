using System;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace KYHBPA.ActionResults
{
    public class ImageResult : ActionResult
    {
        public ImageResult(Stream imageStream, string contentType)
        {
            if (imageStream.IsNull())
                throw new ArgumentNullException(nameof(imageStream));
            if (contentType.IsNull())
                throw new ArgumentNullException(nameof(contentType));

            this.ImageStream = imageStream;
            this.ContentType = contentType;
        }

        public Stream ImageStream { get; private set; }
        public string ContentType { get; private set; }

        public override void ExecuteResult(ControllerContext context)
        {
            if (context.IsNull())
                throw new ArgumentNullException(nameof(context));

            HttpResponseBase response = context.HttpContext.Response;

            response.ContentType = this.ContentType;

            byte[] buffer = new byte[4096];
            while (true)
            {
                int read = this.ImageStream.Read(buffer, 0, buffer.Length);
                if (read == 0)
                    break;

                response.OutputStream.Write(buffer, 0, read);
            }
            response.Flush();
            response.Close();
        }
    }
}