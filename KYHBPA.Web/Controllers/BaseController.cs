using System;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using KYHBPA.Web.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using KYHBPA.Data.Infrastructure;
using KYHBPA.Data.Repository;
using Microsoft.Ajax.Utilities;
using Microsoft.Practices.Unity;

namespace KYHBPA.Web.Controllers
{
    public partial class BaseController : Controller
    {
        protected EntityDbContext Db = EntityDbContext.Create();

        private readonly IUserRepository _userRepository =
            UnityConfig.GetConfiguredContainer().Resolve<IUserRepository>();

        protected IPrincipal CurrentPrincipal => base.User;
        protected IIdentity CurrentIdentity => CurrentPrincipal?.Identity;

        private ApplicationUser _user;
        protected new ApplicationUser User
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
    }
}