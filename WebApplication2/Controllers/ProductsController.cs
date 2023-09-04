using CmsShoppingCart.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using System;
using Microsoft.EntityFrameworkCore;
using CmsShoppingCart.Models;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.DataCollection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Builder;

namespace CmsShoppingCart.Controllers
{
    [Authorize]
    public class ProductsController : Controller
    {
       

        private readonly CmsShoppingCartContext context;
        /* private static List<Product> _searchableData = new List<Product>
         {
             new Product { Id = 1, Name = "Banana", Description = "This is the first sample result." },
             new Product { Id = 2, Name = "Apple", Description = "This is the second sample result." },
             new Product { Id = 3, Name = "Orange", Description = "This is the 3 sample result." },
             new Product { Id = 4, Name = "Grapes", Description = "This is the 4 sample result." },
         };*/
        //private readonly UserManager<AppUser> userManager;
        //private static CmsShoppingCartContext CmsShoppingCart { get; set; } 

       

        public ProductsController(CmsShoppingCartContext context)
        {
            this.context = context;
        }


        /* [HttpPost]
         public IActionResult SearchIndex(String SearchString)
         {
            //var ficOnly = context.Products.Where(b => b.Name.Equals(b.Name));
           // return View(ficOnly.ToListAsync());

             ViewData["CurrentFilter"] = SearchString;
             var product = from b in context.Products
                           select b;
             if (!String.IsNullOrEmpty(SearchString))
             {
                 product = product.Where(b => b.Name.Contains(SearchString));
             }
             return View(product);

         }*/
        public IActionResult Search(/*string searchBy, string searchVlaue*/ string query)
        {
            var results = context.Products.Where(p => p.Name.Contains(query)).ToList();
            return View(results);
        }


        // GET /products
        public async Task<IActionResult> Index(int p = 1)
        {
            int pageSize = 6;
            var products = context.Products.OrderByDescending(x => x.Id).Skip((p - 1) * pageSize).Take(pageSize);


            ViewBag.PageNumber = p;
            ViewBag.PageRange = pageSize;
            ViewBag.TotalPages = (int)Math.Ceiling((decimal)context.Products.Count() / pageSize);

            return View(await products.ToListAsync());
        }

        // GET /products/category
        public async Task<IActionResult> ProductsByCategory(string categorySlug , int p=1)
        {
            Category category =  await context.Categories.Where(x => x.Slug == categorySlug).FirstOrDefaultAsync();

            if (category== null)
            {
                return RedirectToAction("Index");
            }
            int pageSize = 6;
            var products = context.Products.OrderByDescending(x => x.Id)
                                           .Where(x => x.CategoryId == category.Id)
                                           .Skip((p - 1) * pageSize).Take(pageSize);


            ViewBag.PageNumber = p;
            ViewBag.PageRange = pageSize;
            ViewBag.TotalPages = (int)Math.Ceiling((decimal)context.Products.Where(x => x.CategoryId == category.Id).Count() / pageSize);
            ViewBag.CategoryName = category.Name;
            ViewBag.CategorySlug = categorySlug;

            return View(await products.ToListAsync());
        }





/*        public IActionResult SearchIndex(string searchproduct)
        {
            if (string.IsNullOrWhiteSpace(searchproduct))
            {
                return View("Search", new List<Product>());
            }

            var results = _searchableData
                .Where(result =>
                    result.Name.Contains(searchproduct, System.StringComparison.OrdinalIgnoreCase) ||
                    result.Description.Contains(searchproduct, System.StringComparison.OrdinalIgnoreCase));
            return View("Search", results);


        }*/

    }
}
