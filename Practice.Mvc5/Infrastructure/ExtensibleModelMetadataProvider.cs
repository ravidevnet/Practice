using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Practice.Mvc5.Infrastructure
{
    public class ExtensibleModelMetadataProvider
         : DataAnnotationsModelMetadataProvider
    {
        private readonly IModelMetadataFilter[] _metadataFilters;

        public ExtensibleModelMetadataProvider(
            IModelMetadataFilter[] metadataFilters)
        {
            _metadataFilters = metadataFilters;
        }

        protected override System.Web.Mvc.ModelMetadata CreateMetadata(
            IEnumerable<Attribute> attributes,
            Type containerType,
            Func<object> modelAccessor,
            Type modelType,
            string propertyName)
        {
            var metadata = base.CreateMetadata(
                attributes,
                containerType,
                modelAccessor,
                modelType,
                propertyName);

            Array.ForEach(_metadataFilters,m =>
                m.TransformMetadata(metadata, attributes);

            return metadata;
        }
    }
}