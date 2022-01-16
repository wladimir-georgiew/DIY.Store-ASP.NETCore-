using AutoMapper;
using DIY.Castle.Web.Models;
using DIY.Castle.Web.Models.InputModels;
using DIY.Castle.Web.Models.ViewModels;
using DIY.Castle.Web.Services.EmailSender;
using DIY.Castle.Web.Services.ProductsService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DIY.Castle.Web.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMapper mapper;
        private readonly IProductsService productsService;
        private readonly IEmailSender emailSender;

        public HomeController(
            ILogger<HomeController> logger,
            IProductsService productsService,
            IMapper mapper,
            IEmailSender emailSender)
        {
            _logger = logger;
            this.mapper = mapper;
            this.productsService = productsService;
            this.emailSender = emailSender;
        }

        public IActionResult Index()
        {
            var latestProducts = 
                this.productsService.GetAllProducts()
                .OrderByDescending(x => x.CreatedOn)
                .Take(3)
                .Select(x => this.productsService.GetProductModel(x))
                .ToList();

            var randomProducts =
                this.productsService.GetRandomProducts(8)
                .Select(x => this.productsService.GetProductModel(x))
                .ToList();

            var vm = new HomePageViewModel()
            {
                LatestProducts = latestProducts,
                RandomProducts = randomProducts,
            };

            return View(vm);
        }

        public IActionResult Contact()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Contact(ContactInputModel input)
        {
            await this.emailSender.SendEmailAsync($"sneakypeekymustard@gmail.com", $"{input.EmailAddress}", $"ravenouscrow@abv.bg", $"ContactForm by {input.Name}", $"{input.Message}");

            return this.View();
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
