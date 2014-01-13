using System;
using BookSleeve;
using System.Linq;
using System.Collections.Generic;

namespace RedisAB
{
    public class RedisABLogger:IABLogger
    {
        public void LogInitialVisit(string actionName, string viewName)
        {
            using (var conn = new RedisConnection("localhost"))
            {
                conn.Open();
                conn.Strings.Increment(0, String.Format("{0}.{1}", actionName, viewName));
            }
        }

        public void LogSuccess(string actionName, string viewName)
        {
            using (var conn = new RedisConnection("localhost"))
            {
                conn.Open();
                conn.Strings.Increment(0, String.Format("{0}.{1}.success", actionName, viewName));
            }
        }
    }
}