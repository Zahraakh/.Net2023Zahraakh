using Microsoft.AspNetCore.Mvc;
using CmsShoppingCart.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using CmsShoppingCart.Infrastructure;
using System.Linq;

namespace CmsShoppingCart.Areas.Admin.Controllers
{
    
    [Authorize(Roles = "admin")]

    [Area("Admin")]
    public class DiscountsController : Controller
    {
        private readonly CmsShoppingCartContext context;
        public DiscountsController(CmsShoppingCartContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        
        // GET: Discount
        /*  public async Task<IActionResult> Index()
          {
              return View(await context.Discounts.OrderBy(x => x.Sorting).ToListAsync());
          }

          // GET: Discount/Create
         /* public IActionResult Create()
          {
              return View();
          }

          // POST: Discount/Create
          [HttpPost]
          [ValidateAntiForgeryToken]
          public async Task<IActionResult> Create([Bind("DiscountId,DiscountName,DiscountAmount,ProductId")] Discount discount)
          {
              if (ModelState.IsValid)
              {
                  context.Add(discount);
                  await context.SaveChangesAsync();
                  return RedirectToAction(nameof(Index));
              }
              return View(discount);
          }

          // GET: Discount/Edit/5
          public async Task<IActionResult> Edit(int? id)
          {
              if (id == null)
              {
                  return NotFound();
              }

              var discount = await context.Discounts.FindAsync(id);
              if (discount == null)
              {
                  return NotFound();
              }
              return View(discount);
          }

          // POST: Discount/Edit/5
          [HttpPost]
          [ValidateAntiForgeryToken]
          public async Task<IActionResult> Edit(int id, [Bind("DiscountId,DiscountName,DiscountAmount,ProductId")] Discount discount)
          {
              if (id != discount.DiscountID)
              {
                  return NotFound();
              }

              if (ModelState.IsValid)
              {
                  try
                  {
                      context.Update(discount);
                      await context.SaveChangesAsync();
                  }
                  catch (DbUpdateConcurrencyException)
                  {
                      if (!DiscountExists(discount.DiscountID))
                      {
                          return NotFound();
                      }
                      else
                      {
                          throw;
                      }
                  }
                  return RedirectToAction(nameof(Index));
              }
              return View(discount);
          }

          // GET: Discount/Delete/5
          public async Task<IActionResult> Delete(int? id)
          {
              if (id == null)
              {
                  return NotFound();
              }

              var discount = await context.Discounts
                  .FirstOrDefaultAsync(m => m.DiscountId == id);
              if (discount == null)
              {
                  return NotFound();
              }

              return View(discount);
          }

          // POST: Discount/Delete/5
          [HttpPost, ActionName("Delete")]
          [ValidateAntiForgeryToken]
          public async Task<IActionResult> DeleteConfirmed(int id)
          {
              var discount = await context.Discounts.FindAsync(id);
              context.Discounts.Remove(discount);
              await context.SaveChangesAsync();
              return RedirectToAction(nameof(Index));
          }

          private bool DiscountExists(int id)
          {
              return context.Discounts.Any(e => e.DiscountId == id);
          } */
    } 
}
    
