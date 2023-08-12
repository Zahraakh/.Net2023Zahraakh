﻿using CmsShoppingCart.Infrastructure;
using CmsShoppingCart.Migrations;
using CmsShoppingCart.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace CmsShoppingCart.Controllers
{
    public class CartController : Controller
    {
        private readonly CmsShoppingCartContext context;
        public CartController(CmsShoppingCartContext context)
        {
            this.context = context;
        }

        //GET / cart
        public IActionResult Index()
        {
            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart") ?? new List<CartItem>();

            CartViewModel cartVM = new CartViewModel
            {
                CartItems = cart,
                GrandTotal = cart.Sum(x => x.Price * x.Quantity)
        };
            return View( cartVM);
        }
    }
}
