using Microsoft.Practices.Unity;
using Practice.DDD.SharedKernel.Tasks;
using Practice.Mvc5.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Practice.Mvc5
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public IUnityContainer Container
        {
            get { return (IUnityContainer)HttpContext.Current.Items["_Container"]; }
            set { HttpContext.Current.Items["_Container"] = value; }
        }

        private static IUnityContainer _container;
        protected void Application_Start()
        {

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            _container = new UnityContainer();
            DependencyResolver.SetResolver(new UnityDependencyResolver(Container ?? _container));
        }

        public void Application_BeginRequest()
        {
            Container = _container.CreateChildContainer();
            foreach (var task in Container.ResolveAll<IRunOnEachRequest>())
            {
                task.Execute();
            }
        }

        public void Application_Error()
        {
            foreach (var task in Container.ResolveAll<IRunOnError>())
            {
                task.Execute();
            }
        }

        public void Application_EndRequest()
        {
            try
            {
                foreach (var task in
                    Container.ResolveAll<IRunAfterEachRequest>())
                {
                    task.Execute();
                }
            }
            finally
            {
                Container.Dispose();
                Container = null;
            }
        }
    }
}
