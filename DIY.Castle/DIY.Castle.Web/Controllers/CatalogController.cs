using DIY.Castle.Web.Services.ProductsService;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace DIY.Castle.Web.Controllers
{
    public class CatalogController : BaseController
    {
        private readonly IProductsService productsService;

        public CatalogController(IProductsService productsService)
        {
            this.productsService = productsService;
        }

        public IActionResult Index()
        {
            var productModels = this.productsService.GetAllProducts().Select(x => this.productsService.GetProductModel(x)).ToList();

            // TODO : Make service to show all products
            // TODO : Add filtration options
            // TODO : Add pagination
            return View(productModels);
        }
    }
}
