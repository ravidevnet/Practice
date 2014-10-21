using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Practice.Mvc5.Infrastructure
{
    public class UnityDependencyResolver : IDependencyResolver
    {
        private readonly IUnityContainer _container;

        public UnityDependencyResolver(IUnityContainer container)
        {
            _container = container;
        }
        public object GetService(Type serviceType)
        {
            if (typeof(IController).IsAssignableFrom(serviceType))
            {
                return _container.Resolve(serviceType);
            }
            return IsRegistered(serviceType) ? _container.Resolve(serviceType) : null;
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            if (IsRegistered(serviceType))
            {
                yield return _container.Resolve(serviceType);
            }

            foreach (var service in _container.ResolveAll(serviceType))
            {
                yield return service;
            }
        }


        private bool IsRegistered(Type typeToCheck)
        {
            var isRegistered = true;
            if (typeToCheck.IsInterface || typeToCheck.IsAbstract)
            {
                isRegistered = _container.IsRegistered(typeToCheck);
                if (!isRegistered && typeToCheck.IsGenericType)
                {
                    var openGenriceTpe = typeToCheck.GetGenericTypeDefinition();
                    isRegistered = _container.IsRegistered(openGenriceTpe);
                }
            }
            return isRegistered;
        }
    }
}