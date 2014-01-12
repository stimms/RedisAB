using System;
using System.Linq;
using System.Collections.Generic;

namespace RedisAB
{
    public interface IABLogger
    {
        void LogInitialVisit(string actionName, string viewName);
        void LogSuccess(string actionName, string viewName);
    }
}
