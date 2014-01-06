using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RedisAB
{
    public interface IABSelector
    {
        string Select(string viewName, ControllerContext context);
    }
}