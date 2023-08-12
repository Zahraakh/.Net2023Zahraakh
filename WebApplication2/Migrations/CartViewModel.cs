﻿using CmsShoppingCart.Models;
using System.Collections.Generic;

namespace CmsShoppingCart.Migrations
{
    public class CartViewModel
    {
        public List<CartItem> CartItems { get; set; }
        public decimal GrandTotal { get; set; }
    }
}
