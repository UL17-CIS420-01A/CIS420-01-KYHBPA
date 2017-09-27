using System;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using KYHBPA.Web.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using KYHBPA.Data.Infrastructure;
using KYHBPA.Data.Repository;

namespace KYHBPA.Web.Controllers
{
    public partial class BaseController : Controller
    {
        protected EntityDbContext Db = EntityDbContext.Create();
        private UserStore<ApplicationUser> _userStore;
        private UserManager<ApplicationUser> _userManager;

        protected UserStore<ApplicationUser> UserStore
        {
            get { return _userStore ?? (UserStore = new UserStore<ApplicationUser>(Db)); }
            set { _userStore = value; }
        }

        protected UserManager<ApplicationUser> UserManager
        {
            get
            {
                return _userManager ?? /**/ (UserManager = new UserManager<ApplicationUser>(UserStore)) /*/ 
                    HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>() /**/;
            } // TODO Get UserManager from OwinContext or by constructor?
            set { _userManager = value; }
        }

        protected IPrincipal CurrentPrincipal => base.User;
        protected IIdentity CurrentIdentity => CurrentPrincipal?.Identity;
        public new ApplicationUser User
        {
            get
            {
                //var user = UserManager.FindByIdAsync(CurrentIdentity?.GetUserId()).Result;
                //if(user != null)
                //{
                //    user.Member = Db.Users.Find(user.Id).Member;
                //}
                //return user;
                return (new UserRepository(Db)).FindById(CurrentIdentity?.GetUserId());
            }
        }
        //public new ApplicationUser User => HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(CurrentIdentity?.GetUserId());

    }
}