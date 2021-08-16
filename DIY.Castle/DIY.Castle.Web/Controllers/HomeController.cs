using AutoMapper;
using DIY.Castle.Web.Models;
using DIY.Castle.Web.Services.ProductsService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Linq;

namespace DIY.Castle.Web.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMapper mapper;
        private readonly IProductsService productsService;

        public HomeController(
            ILogger<HomeController> logger,
            IProductsService productsService,
            IMapper mapper)
        {
            _logger = logger;
            this.mapper = mapper;
            this.productsService = productsService;
        }

        public IActionResult Index()
        {
            this.ViewData["showBigHeroBanner"] = true;
            this.ViewData["titleText"] = "Title text";
            this.ViewData["descriptionText"] = "Description text";

            var latestProductsViewModel = 
                this.productsService.GetAllProducts()
                .OrderByDescending(x => x.CreatedOn)
                .Take(3)
                .Select(x => mapper.Map<ProductModel>(x))
                .ToList();

            return View(latestProductsViewModel);
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
