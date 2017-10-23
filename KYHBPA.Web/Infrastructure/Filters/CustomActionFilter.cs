using System.Web.Mvc;

namespace KYHBPA
{

    public class CustomActionFilter : IResultFilter, IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //throw new NotImplementedException();
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            //throw new NotImplementedException();
        }

        // Method Here

        public void OnResultExecuting(ResultExecutingContext filterContext)
        {
            //throw new NotImplementedException();
        }

        public void OnResultExecuted(ResultExecutedContext filterContext)
        {
            //throw new NotImplementedException();
        }

    }
}