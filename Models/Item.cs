using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionTracker.Models
{
    public class Item
    {
        public int ItemId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Series { get; set; }  // Series added here

        public List<CollectionItem> CollectionItems { get; set; } // Many-to-many relationship
    }

}
