using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration.Configuration;

namespace CompetitionFisher.Data.Infrastructure
{
    public static class TypeConfigurationExtensions
    {
        public static PrimitivePropertyConfiguration HasIndexAnnotation(
            this PrimitivePropertyConfiguration property,
            string indexName,
            bool isUnique,
            int columnOrder = 0)
        {
            var indexAttribute = new IndexAttribute(indexName, columnOrder) { IsUnique = isUnique };
            var indexAnnotation = new IndexAnnotation(indexAttribute);

            return property.HasColumnAnnotation(IndexAnnotation.AnnotationName, indexAnnotation);
        }
    }
}
