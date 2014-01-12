using System;
using System.Linq;
using System.Web.Mvc;
using System.Collections.Generic;

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