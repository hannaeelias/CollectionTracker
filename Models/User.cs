﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionTracker.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string AccessKey { get; set; }

        public List<Collection> Collections { get; set; }
        public List<Wishlist> Wishlists { get; set; }
    }
}
