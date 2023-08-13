using CmsShoppingCart.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CmsShoppingCart.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {

        private readonly UserManager<AppUser> userManager;

        public UserController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager,
            IPasswordHasher<AppUser> passwordHasher)
        {
            this.userManager = userManager;

        }

        public IActionResult Index()
        {
            return View(userManager.Users);
        }
    }
}
