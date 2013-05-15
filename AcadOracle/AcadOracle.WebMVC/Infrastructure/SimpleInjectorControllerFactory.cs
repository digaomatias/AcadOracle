using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AcadOracle.WebMVC.Infrastructure
{
    public class SimpleInjectorControllerFactory : DefaultControllerFactory
    {
        private readonly SimpleInjector.Container container; 

        public SimpleInjectorControllerFactory(SimpleInjector.Container container)
        {
            this.container = container;
        }   
        
        protected override IController GetControllerInstance(System.Web.Routing.RequestContext requestContext, Type controllerType)
        {
            if (controllerType != null)
            {
                return container.GetInstance(controllerType) as IController;
            }

 	         return base.GetControllerInstance(requestContext, controllerType);
        }
    }
}