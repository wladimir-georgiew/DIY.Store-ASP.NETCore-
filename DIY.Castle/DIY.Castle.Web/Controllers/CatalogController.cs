using DIY.Castle.Common;
using DIY.Castle.Web.Models;
using DIY.Castle.Web.Services.ProductsService;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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

        public IActionResult Index(int page = 1)
        {
            var productModels = this.productsService
                .GetAllProducts()
                .OrderByDescending(x => x.CreatedOn)
                .Select(x => this.productsService.GetProductModel(x))
                .ToList();

            // TODO : Make service to show all products
            // TODO : Add filtration options
            // TODO : Add pagination

            var viewModel = PaginationList<ProductModel>.Create(productModels, page, 12);
            return View(viewModel);
        }
    }
}
