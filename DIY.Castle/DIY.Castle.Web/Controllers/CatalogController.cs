using DIY.Castle.Common;
using DIY.Castle.Web.Models;
using DIY.Castle.Web.Services.ProductsService;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace DIY.Castle.Web.Controllers
{
    public class CatalogController : BaseController
    {
        private readonly IProductsService productsService;

        public CatalogController(IProductsService productsService)
        {
            this.productsService = productsService;
        }

        public IActionResult Index(string filter = null, int page = 1)
        {
            var productModels = this.productsService
                .GetProductsByType(filter)
                .OrderByDescending(x => x.CreatedOn)
                .Select(x => this.productsService.GetProductModel(x))
                .ToList();

            var viewModel = PaginationList<ProductModel>.Create(productModels, page, 12);
            return View(viewModel);
        }
    }
}
