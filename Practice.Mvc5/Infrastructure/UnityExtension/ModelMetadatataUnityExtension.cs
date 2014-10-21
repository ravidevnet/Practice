using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;

namespace Practice.Mvc5.Infrastructure.UnityExtension
{
    public class ModelMetadatataUnityExtension:UnityContainerExtension
    {
        protected override void Initialize()
        {
            Context.Container.RegisterType<ModelMetadataProvider, ExtensibleModelMetadataProvider>();
        }
    }
}