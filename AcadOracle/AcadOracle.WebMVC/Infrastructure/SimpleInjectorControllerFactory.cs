using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AcadOracle.WebMVC.Infrastructure
{
    public class SimpleInjectorControllerFactory : DefaultControllerFactory
    {
        private readonly ISimpleInjectorContainer

        public SimpleInjectorControllerFactory(IControllerFactory factory)
        {
            
        }

        protected override IController GetControllerInstance(System.Web.Routing.RequestContext requestContext, Type controllerType)
{
 	 return base.GetControllerInstance(requestContext, controllerType);
}
    }
}