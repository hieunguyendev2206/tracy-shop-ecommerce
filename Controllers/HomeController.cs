using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TracyShop.Data;
using TracyShop.Models;
using TracyShop.ViewModels;

namespace TracyShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var products = new List<ProductsListViewModel>();
            var images = new List<Image>();
            var qr = _context.Image.ToList();
            foreach (var img in qr) images.Add(img);

            foreach (var p in _context.Product.ToList().OrderByDescending(p => p.Price).Take(8))
                if (p.Active)
                {
                    var pro = new ProductsListViewModel();
                    if (images.Where(img => img.ProductId == p.Id).Count() <= 0)
                        pro.ImageDefault = "";
                    else
                        pro.ImageDefault = images.Where(img => img.ProductId == p.Id).First().Path;

                    // Kiểm tra số lượng sản phẩm trong kho
                    var quantity = _context.ProductSize.Where(ps => ps.ProductId == p.Id).ToList();
                    var totalQuantity = 0;
                    foreach (var item in quantity) totalQuantity += item.Quantity;

                    pro.Id = p.Id;
                    pro.Name = p.Name;
                    pro.Count = totalQuantity;
                    pro.Price = p.Price;
                    products.Add(pro);
                }

            ViewBag.ProductList = products;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}