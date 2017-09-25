using System;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using KYHBPA.Web.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

namespace KYHBPA.Web.Controllers
{
    public partial class BaseController : Controller
    {
        protected ApplicationDbContext Db = ApplicationDbContext.Create();
        private UserStore<ApplicationUser> _userStore;
        private UserManager<ApplicationUser> _userManager;

        protected UserStore<ApplicationUser> UserStore
        {
            get { return _userStore ?? (UserStore = new UserStore<ApplicationUser>(Db)); }
            set { _userStore = value; }
        }

        protected UserManager<ApplicationUser> UserManager
        {
            get { return _userManager ?? /**/ (UserManager = new UserManager<ApplicationUser>(UserStore)) /*/ 
                    HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>() /**/; } // TODO Get UserManager from OwinContext or by constructor?
            set { _userManager = value; }
        }

        protected IPrincipal CurrentPrincipal => base.User;
        protected IIdentity CurrentIdentity => CurrentPrincipal?.Identity;
        //UserManager.FindByIdAsync(CurrentIdentity?.GetUserId()).Result;
        protected new ApplicationUser User => HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(CurrentIdentity?.GetUserId()); //(CurrentIdentity?.GetUserId())
    }
}