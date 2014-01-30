using System;
using System.Linq;
using System.Web.Mvc;
using System.Collections.Generic;

namespace RedisAB.Controllers
{
    public class BaseController:Controller
    {
        public IABSelector ABSelector { get; set; }
        public IABLogger ABLogger { get; set; }
        protected override ViewResult View(string viewName, string masterName, object model)
        {
            viewName = InterceptViewForABTesting(viewName, masterName);
            return base.View(viewName, masterName, model);
        }
        private string InterceptViewForABTesting(string viewName, string masterName)
        {
            string action = ControllerContext.RouteData.GetRequiredString("action");
            var resolvedViewName = viewName ?? action;
            if (ThereAreNoValidViews(resolvedViewName, masterName))
            {
                var selectedView = ABSelector.Select(resolvedViewName, ControllerContext);
                LogSelectedView(action, selectedView);
                ViewBag.ViewName = selectedView;
                return selectedView;
            }
            return resolvedViewName;
        }
        private bool ThereAreNoValidViews(string viewName, string masterName)
        {
            var possibleViews = ViewEngineCollection.FindView(ControllerContext, viewName, masterName ?? String.Empty);
            return possibleViews.View == null;
        }
        private void LogSelectedView(string actionName, string viewName)
        {
            ABLogger.LogInitialVisit(actionName, viewName);
        }
    }
}