using AutoMapper;
using DIY.Castle.Data.Models;
using DIY.Castle.Web.Areas.Administration.Models;
using DIY.Castle.Web.Areas.Administration.Models.Variations;
using DIY.Castle.Web.Services.CategoriesService;
using DIY.Castle.Web.Services.ProductsService;
using DIY.Castle.Web.Services.ProductVariationsService;
using DIY.Castle.Web.Services.UploadFileService;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIY.Castle.Web.Areas.Administration.Controllers
{
    public class ProductVariationsController : AdministrationController
    {
        private readonly IProductsService _productsService;
        private readonly IProductVariationsService productVariationsService;

        public ProductVariationsController(IProductsService productsService, IProductVariationsService productVariationsService)
        {
            this._productsService = productsService;
            this.productVariationsService = productVariationsService;
        }

        [HttpGet]
        public IActionResult Add(int productId)
        {
            var product = this._productsService.GetProductById(productId);

            var model = new CreateVariationProductRequestModel();
            model.ProductId = productId;

            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateVariationProductRequestModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            await this.productVariationsService.CreateVariation(model);

            return RedirectToAction("Product", "ProductDetails", new { area = "", id = model.ProductId });
        }

        [HttpGet]
        public IActionResult Edit(int variationId)
        {
            var variation = this._productsService.GetVariationById(variationId);

            var model = new EditVariationProductRequestModel();
            model.VariationId = variationId;
            model.ProductId = variation.ProductId;
            model.Name = variation.VariationName;
            model.Price = variation.Price;

            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditVariationProductRequestModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var variation = await this.productVariationsService.EditVariation(model);

            return RedirectToAction("Product", "ProductDetails", new { area = "", id = variation.ProductId });
        }

        public async Task<IActionResult> Delete(int variationId)
        {
            var variation = this._productsService.GetVariationById(variationId);

            await this.productVariationsService.DeleteVariation(variation);

            return RedirectToAction("Product", "ProductDetails", new { area = "", id = variation.ProductId });
        }
    }
}
