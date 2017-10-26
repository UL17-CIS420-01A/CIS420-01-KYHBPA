using System;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;

namespace KYHBPA
{
    public class SoftDeleteAttribute : Attribute
    {
        public SoftDeleteAttribute(string column)
        {
            ColumnName = column;
        }

        public string ColumnName { get; set; }

        public static string GetSoftDeleteColumnName(EdmType type)
        {
            MetadataProperty annotation = type.MetadataProperties
                .SingleOrDefault(p => p.Name.EndsWith("customannotation:SoftDeleteColumnName"));

            return (string) annotation?.Value;
        }
    }
}
