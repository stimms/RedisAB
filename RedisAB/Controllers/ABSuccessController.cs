using System;
using System.Linq;
using System.Web.Mvc;
using System.Collections.Generic;

namespace RedisAB.Controllers
{
    public class ABSuccessController : Controller
    {
        public IABLogger ABLogger { get; set; }

        [HttpPost]
        public void Index(string actionName, string viewName)
        {
            ABLogger.LogSuccess(actionName, viewName);
        }
    }
}