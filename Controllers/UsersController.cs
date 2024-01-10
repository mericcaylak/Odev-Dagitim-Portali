using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using uyg05_IdentityApp.Models;
using uyg05_IdentityApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using System.Linq;

namespace uyg05_IdentityApp.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UsersController : Controller
    {
        private readonly AppDbContext _context;

        public UsersController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult UserListAjax()
        {
            // Örnek kullanıcı adları
            string adminUsername = "merich";
            string memberUsername = "eylul";

            var userModels = _context.Users.Select(x => new UserModel()
            {
                Id = x.Id,
                FullName = x.FullName,
                Email = x.Email,
                UserName = x.UserName,
                City = x.City,
                Role = (x.UserName == adminUsername ) ? "Admin" : "Uye"
            }).ToList();

            return Json(userModels);
        }
    }
}

