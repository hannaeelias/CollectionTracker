using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionTracker.Models
{
    public class Wishlist
    {
        public int WishlistId { get; set; }
        public int ItemId { get; set; }
        public int UserId { get; set; }
        public int Priority { get; set; }
    }
}
