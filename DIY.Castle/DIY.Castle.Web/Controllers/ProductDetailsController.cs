using AutoMapper;
using DIY.Castle.Web.Models;
using DIY.Castle.Web.Models.ViewModels;
using DIY.Castle.Web.Services.ProductsService;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace DIY.Castle.Web.Controllers
{
    public class ProductDetailsController : BaseController
    {
        private readonly IProductsService productsService;
        private readonly IMapper mapper;

        public ProductDetailsController(IProductsService productsService, IMapper mapper)
        {
            this.productsService = productsService;
            this.mapper = mapper;
        }

        [Route("Product/{id}")]
        public IActionResult Product(int id)
        {
            var product = this.productsService.GetProductById(id);
            var vm = productsService.GetProductModel(product);

            return View(vm);
        }
    }
}
