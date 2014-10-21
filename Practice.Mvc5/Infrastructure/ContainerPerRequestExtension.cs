using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Practice.Mvc5.Infrastructure
{
    public static class ContainerPerRequestExtension
    {
        public static IUnityContainer GetContainer(this HttpContextBase context)
        {
            return (IUnityContainer)HttpContext.Current.Items["_container"];
        }
    }
}