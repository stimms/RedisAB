using System;
using Autofac;
using System.Linq;
using System.Web.Mvc;
using System.Reflection;
using Autofac.Integration.Mvc;
using System.Collections.Generic;

namespace RedisAB
{
    public class ContainerConfig
    {
        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<DefaultABSelector>().AsImplementedInterfaces();
            builder.RegisterType<RedisABLogger>().AsImplementedInterfaces();
            builder.RegisterModelBinders(Assembly.GetExecutingAssembly());
            builder.RegisterControllers(Assembly.GetExecutingAssembly()).PropertiesAutowired();
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}