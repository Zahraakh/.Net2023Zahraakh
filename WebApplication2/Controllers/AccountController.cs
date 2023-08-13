using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CmsShoppingCart.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        //GET /account/register
        [AllowAnonymous]
        public IActionResult Register() => View();
        
    }
}
