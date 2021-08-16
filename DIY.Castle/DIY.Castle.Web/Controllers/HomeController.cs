using DIY.Castle.Web.Models;
using DIY.Castle.Web.Services.ProductsService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace DIY.Castle.Web.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductsService productdService;

        public HomeController(ILogger<HomeController> logger, IProductsService productdService)
        {
            _logger = logger;
            this.productdService = productdService;
        }

        public IActionResult Index()
        {
            this.ViewData["showBigHeroBanner"] = true;
            this.ViewData["titleText"] = "Title text";
            this.ViewData["descriptionText"] = "Description text";

            var LatestProdcutsViewModel = this.productdService.GetLatestProducts();

            return View(LatestProdcutsViewModel);
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
