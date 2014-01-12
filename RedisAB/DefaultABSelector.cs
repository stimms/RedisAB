using System;
using System.Web;
using System.Linq;
using System.Web.Mvc;
using System.Collections.Generic;

namespace RedisAB
{
    public class DefaultABSelector : IABSelector
    {

        public string Select(string viewName, ControllerContext context)
        {
            if (context.HttpContext.User.Identity.IsAuthenticated)
                return SelectAuthenticatedGroup(viewName, context);
            return SelectUnauthenticatedGroup(viewName, context);
        }
        private string SelectAuthenticatedGroup(string viewName, ControllerContext context)
        {
            var hashValue = context.HttpContext.User.Identity.Name.GetHashCode();
            if (IsEven(hashValue))
                return viewName + "A";
            return viewName + "B";
        }
        private string SelectUnauthenticatedGroup(string viewName, ControllerContext context)
        {
            var hashValue = GetIPAddress(context.HttpContext).GetHashCode();
            if (IsEven(hashValue))
                return viewName + "A";
            return viewName + "B";
        }

        private static bool IsEven(int hashValue)
        {
            return hashValue % 2 == 0;
        }
        protected string GetIPAddress(HttpContextBase context)
        {
            string ipAddress = context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

            if (!string.IsNullOrEmpty(ipAddress))
            {
                string[] addresses = ipAddress.Split(',');
                if (addresses.Any())
                {
                    return addresses.First();
                }
            }

            return context.Request.ServerVariables["REMOTE_ADDR"];
        }
    }
}
