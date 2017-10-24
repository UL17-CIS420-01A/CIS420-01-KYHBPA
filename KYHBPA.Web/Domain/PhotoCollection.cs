using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace KYHBPA
{
    public class PhotoCollection
    {
        public PhotoCollection(IEnumerable<Photo> collection, string key)
        {
            this.Collection = collection?.ToList() ?? throw new ArgumentNullException(nameof(collection));
            this.Key = key ?? throw new ArgumentNullException(nameof(key));
        }

        [Key, Required]
        [Column(Order = 0)]
        public List<Photo> Collection { get; set; }

        [Key, Required]
        [Column(Order = 1)]
        public string Key { get; set; }
    }
}