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
    public class BaseController : Controller
    {
        protected ApplicationDbContext Db = ApplicationDbContext.Create();
        private UserStore<ApplicationUser> _userStore;
        private UserManager<ApplicationUser> _userManager;


        public BaseController()
        {
        }

        //protected ApplicationDbContext Db
        //{
        //    get { return _db ?? (Db = new ApplicationDbContext()); }
        //    set { _db = value; }
        //}

        protected UserStore<ApplicationUser> UserStore
        {
            get { return _userStore ?? (UserStore = new UserStore<ApplicationUser>(Db)); }
            set { _userStore = value; }
        }

        protected UserManager<ApplicationUser> UserManager
        {
            get { return _userManager ?? (UserManager = new UserManager<ApplicationUser>(UserStore)); }
            set { _userManager = value; }
        }

        protected IPrincipal CurrentPrincipal => base.User;
        protected IIdentity CurrentIdentity => CurrentPrincipal?.Identity;
        protected new ApplicationUser User => //UserManager.FindByIdAsync(CurrentIdentity?.GetUserId()).Result;
        HttpContext.GetOwinContext().Get<ApplicationUser>(CurrentIdentity?.GetUserId());
        //public ApplicationUser User()
        //{
        //    return db.Users.SingleOrDefault(user => user.Id == AspNetUser.Identity.GetUserId());
        //}

        //public ApplicationUser GetApplicationUser()
        //{
        //    return db.Users.SingleOrDefault(user => user.Id == User.Identity.GetUserId());
        //}
    }
}