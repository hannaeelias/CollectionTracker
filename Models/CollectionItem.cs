using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionTracker.Models
{
    public class CollectionItem
    {
        public int CollectionId { get; set; }
        public int ItemId { get; set; }

        public Collection Collection { get; set; }
        public Item Item { get; set; }

        // Composite key
        public class CollectionItemKey
        {
            public int CollectionId { get; set; }
            public int ItemId { get; set; }
        }
    }
}