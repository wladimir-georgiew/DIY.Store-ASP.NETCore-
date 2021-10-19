using AutoMapper;
using DIY.Castle.Data.Models;
using DIY.Castle.Web.Areas.Administration.Models;
using DIY.Castle.Web.Services.ProductsService;
using DIY.Castle.Web.Services.UploadFileService;
using GlobalConstants;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIY.Castle.Web.Areas.Administration.Controllers
{
    public class ProductsController : AdministrationController
    {
        private readonly IMapper _mapper;
        private readonly IUploadFileService _uploadFileService;
        private readonly IProductsService _productsService;

        public ProductsController(IMapper mapper, IUploadFileService uploadFileService, IProductsService productsService)
        {
            this._mapper = mapper;
            this._uploadFileService = uploadFileService;
            this._productsService = productsService;
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = new ProductsRequestModel();
            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductsRequestModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var product = this._mapper.Map<ProductsRequestModel, Product>(model);
            product.ProductType = model.ProductType;

            var productImgSourcePaths = string.Empty;

            var imgIndex = 0;
            foreach (var img in model.Images)
            {
                var imgSeparator = imgIndex != 0 ? CommonConstants.ImageSeparator : string.Empty;
                productImgSourcePaths += (imgSeparator + this._uploadFileService.UploadFile(img));

                imgIndex++;
            }

            product.ImageSourcePath = productImgSourcePaths;
            await this._productsService.AddProduct(product);

            return this.RedirectToAction("Index", "Home", new { area = "" });
        }
    }
}
