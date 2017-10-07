using System.Data.Common;
using System.Data.Entity;
using AutoMapper;
using KYHBPA.Data.Infrastructure;

namespace KYHBPA.Web
{
    using System;
    using Microsoft.Practices.Unity;
    using Microsoft.Practices.Unity.Configuration;
    using Microsoft.AspNet.Identity;
    using KYHBPA.Web.Models;
    using Microsoft.AspNet.Identity.EntityFramework;
    using KYHBPA.Data.Repository;
    using KYHBPA.Web.Controllers;

    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        /// <summary>
        /// Gets the configured Unity container.
        /// </summary>
        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }
        #endregion

        /// <summary>Registers the type mappings with the Unity container.</summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>There is no need to register concrete types such as controllers or API controllers (unless you want to 
        /// change the defaults), as Unity allows resolving a concrete type even if it was not previously registered.</remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below. Make sure to add a Microsoft.Practices.Unity.Configuration to the using statements.
            //container.LoadConfiguration();

            // TODO: Register your types here
            container.RegisterType<IUserStore<ApplicationUser, Guid>, ApplicationUserStore>();
            container.RegisterType<AccountController>(new InjectionConstructor());
            container.RegisterType<ManageController>(new InjectionConstructor());
            container.RegisterType<DbContext, EntityDbContext>();
            container.RegisterType<EntityDbContext>(new InjectionFactory(c => new EntityDbContextFactory().Create()));
            container.RegisterType<Mapper>();
            container.RegisterType<IUserRepository, UserRepository>();
            //container.RegisterType<IRepository<User, string>, UserRepository>();
        }
    }
}
