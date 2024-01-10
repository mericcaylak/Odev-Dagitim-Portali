using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using uyg05_IdentityApp.Models;
using uyg05_IdentityApp.ViewModels;

namespace uyg05_IdentityApp.Controllers
{
    public class HomeworkController : Controller
    {
        private readonly AppDbContext _context;

        public HomeworkController(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        [Authorize(Roles="Admin")]
        public IActionResult Index()
        {
            var productsModel = _context.Products.Select(x => new HomeworkModel()
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Price = x.Price,
                Status = x.Status

            }).ToList();
            return View(productsModel);
        }
        public IActionResult Detail(int id)
        {
            var productModel = _context.Products.Select(x => new HomeworkModel()
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Price = x.Price,
                Status = x.Status

            }).SingleOrDefault(x => x.Id == id);
            return View(productModel);

        }
        public IActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Insert(HomeworkModel model)
        {
            var product = new Homework();
            product.Name = model.Name;
            product.Description = model.Description;
            product.Price = model.Price;
            product.Status = model.Status;

            _context.Products.Add(product);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            var productModel = _context.Products.Select(x => new HomeworkModel()
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Price = x.Price,
                Status = x.Status

            }).SingleOrDefault(x => x.Id == id);
            return View(productModel);
        }

        [HttpPost]
        public IActionResult Edit(HomeworkModel model)
        {
            var product = _context.Products.SingleOrDefault(x => x.Id == model.Id);
            product.Name = model.Name;
            product.Description = model.Description;
            product.Price = model.Price;
            product.Status = model.Status;

            _context.Products.Update(product);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var productModel = _context.Products.Select(x => new HomeworkModel()
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Price = x.Price,
                Status = x.Status

            }).SingleOrDefault(x => x.Id == id);
            return View(productModel);
        }

        [HttpPost]
        public IActionResult Delete(HomeworkModel model)
        {
            var product = _context.Products.SingleOrDefault(x => x.Id == model.Id);
            _context.Products.Remove(product);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        public IActionResult ChangeStatus(int id, bool st)
        {
            var product = _context.Products.SingleOrDefault(x => x.Id == id);
            product.Status = st;
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
