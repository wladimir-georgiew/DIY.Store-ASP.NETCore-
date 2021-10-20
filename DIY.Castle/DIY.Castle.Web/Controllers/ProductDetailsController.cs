using DIY.Castle.Web.Services.ProductsService;
using Microsoft.AspNetCore.Mvc;

namespace DIY.Castle.Web.Controllers
{
    public class ProductDetailsController : BaseController
    {
        private readonly IProductsService productsService;

        public ProductDetailsController(IProductsService productsService)
        {
            this.productsService = productsService;
        }

        [Route("Product/{id}")]
        public IActionResult Product(int id)
        {
            var product = this.productsService.GetProductById(id);
            var productModel = this.productsService.GetProductModel(product);

            return View(productModel);
        }
    }
}
