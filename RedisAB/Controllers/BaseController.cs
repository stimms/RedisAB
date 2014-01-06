using System;
using System.Linq;
using System.Web.Mvc;
using System.Collections.Generic;

namespace RedisAB.Controllers
{
    public class BaseController:Controller
    {
        public IABSelector ABSelector { get; set; }
        protected override ViewResult View(string viewName, string masterName, object model)
        {
            viewName = InterceptViewForABTesting(viewName, masterName);
            return base.View(viewName, masterName, model);
        }
        private string InterceptViewForABTesting(string viewName, string masterName)
        {
            var resolvedViewName = viewName ?? ControllerContext.RouteData.GetRequiredString("action");
            if (ThereAreNoValidViews(resolvedViewName, masterName))
            {
                return ABSelector.Select(resolvedViewName, ControllerContext);
            }
            return resolvedViewName;
        }
        private bool ThereAreNoValidViews(string viewName, string masterName)
        {
            var possibleViews = ViewEngineCollection.FindView(ControllerContext, viewName, masterName ?? String.Empty);
            return possibleViews.View == null;
        }
    }
}