using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionTracker.Models
{
    public class Collection
    {
        public int CollectionId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

        public List<CollectionItem> CollectionItems { get; set; }  // Many-to-many relationship through junction table


    }
}
