using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace TracyShop.Controllers
{
    public class AboutController : Controller
    {
        private readonly ILogger<AboutController> _logger;

        public AboutController(ILogger<AboutController> logger)
        {
            _logger = logger;
        }

        [Route("/about", Name = "about")]
        public IActionResult About()
        {
            return View();
        }
    }
}