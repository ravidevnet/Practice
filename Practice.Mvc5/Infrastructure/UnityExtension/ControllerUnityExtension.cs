using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Practice.Mvc5.Infrastructure.UnityExtension
{
    public class ControllerUnityExtension:UnityContainerExtension
    {
        protected override void Initialize()
        {
            Context.Container.RegisterTypes(
                AllClasses.FromLoadedAssemblies().Where(type=>typeof(Controller).IsAssignableFrom(type)),
                WithMappings.None,
                WithName.Default,
                WithLifetime.Transient
                );
        }
    }
}