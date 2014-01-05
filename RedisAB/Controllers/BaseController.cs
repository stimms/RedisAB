using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RedisAB.Controllers
{
    public class BaseController:Controller
    {
        public IABSelector ABSelector { get; set; }
        protected override ViewResult View(string viewName, string masterName, object model)
        {
            if (ThereAreNoValidViews(viewName, masterName))
            {
                viewName = ABSelector.Select(viewName, ControllerContext);
            }
            return base.View(viewName, masterName, model);
        }
        private bool ThereAreNoValidViews(string viewName, string masterName)
        {
            var possibleViews = ViewEngineCollection.FindView(ControllerContext, viewName ?? ControllerContext.RouteData.GetRequiredString("action"), masterName ?? String.Empty);
            return possibleViews.View == null;
        }
    }
}