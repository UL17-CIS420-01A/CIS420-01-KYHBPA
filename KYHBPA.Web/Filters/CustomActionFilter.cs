﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KYHBPA.Web.Filters
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