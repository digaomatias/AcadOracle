using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AcadOracle.WebMVC.Infrastructure.ActionFilters
{
    public class BindArrayAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var keys = filterContext.HttpContext.Request.QueryString.AllKeys.Where(p => p.StartsWith("id"));

            var idArray = new string[keys.Count()];

            var counter = 0;
            foreach (var key in keys)
            {
                var turma = filterContext.HttpContext.Request.QueryString[key];
                idArray[counter] = turma;
                counter++;
            }

            filterContext.ActionParameters["turmas"] = idArray;

            base.OnActionExecuting(filterContext);
        }
    }
}