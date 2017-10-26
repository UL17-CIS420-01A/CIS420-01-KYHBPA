using System;
using System.IO;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using KYHBPA.Data.Infrastructure;
using KYHBPA.ActionResults;
using KYHBPA.Repository;
using Microsoft.Ajax.Utilities;
using Microsoft.Practices.Unity;
using static System.Drawing.Image;

namespace KYHBPA.Controllers
{
    public partial class BaseController : Controller
    {
        protected EntityDbContext Db = EntityDbContext.Create();

        private readonly IUserRepository _userRepository =
            UnityConfig.GetConfiguredContainer().Resolve<IUserRepository>();

        protected IPrincipal CurrentPrincipal => base.User;
        protected IIdentity CurrentIdentity => CurrentPrincipal?.Identity;

        private ApplicationUser _user;
        public new ApplicationUser User
        {
            get
            {
                if (_user.IsNull())
                {
                    var id = CurrentIdentity?.GetUserId();
                    if (id.IsNullOrWhiteSpace())
                        return null;
                    if (Guid.TryParse(id, out Guid guid))
                        _user = this._userRepository.FindById(guid);
                    else
                        return null;
                }
                return _user;
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                Db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ImageResult ImageNotAvailable
        {
            get
            {
                var imageResult = new ImageResult(
                    new MemoryStream(FromFile(Server.MapPath(@"~/content/images/ImageNotAvailable.jpg")).ToByteArray()), "image/jpeg");
                return imageResult;
            }
        }

        public ImageResult Image(byte[] imageBytes, string contentType)
        {
            try
            {
                var imageResult = new ImageResult(new MemoryStream(imageBytes), contentType);
                return imageResult;
            }
            catch (Exception ex)
            {
                return ImageNotAvailable;
            }
        }

        //Cache for one day(server and client, vary by id)
        [OutputCache(CacheProfile = "RenderImage", VaryByParam = "id", Duration = 86400, Location = OutputCacheLocation.ServerAndClient, NoStore = false)]
        [HttpGet]
        public async Task<ActionResult> RenderImage(Guid? id)
        {
            if (id.IsNull())
            {
                return ImageNotAvailable;
            }
            Photo photo = await Db.Photos.FindAsync(id);
            if ((photo?.Content).IsEmptyArray())
            {
                return ImageNotAvailable;
            }
            return Image(photo.Content, photo.ContentType);
        }
    }
}