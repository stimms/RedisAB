using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RedisAB
{
    public class RandomABSelector : IABSelector
    {
        public string Select(string viewName, ControllerContext context)
        {
            var random = new Random().Next(0, 2);
            return viewName + (random > 0 ? "A" : "B");
        }
    }
}
