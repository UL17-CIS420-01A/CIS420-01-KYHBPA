using System.Web;
using System.Web.Mvc;
using KYHBPA.Web.Infrastructure.Filters;

namespace KYHBPA.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new CustomActionFilter());
        }
    }
}
