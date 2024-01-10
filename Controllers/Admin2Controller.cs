using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace uyg05_IdentityApp.Controllers
{
    // [Authorize(Roles = "Admin")]

    public class Admin2Controller : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
