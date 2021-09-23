using AutoMapper;
using DIY.Castle.Data.Models;
using DIY.Castle.Web.Areas.Administration.Models;
using DIY.Castle.Web.Services.ProductsService;
using DIY.Castle.Web.Services.UploadFileService;
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
            product.ImageSourcePath = this._uploadFileService.UploadFile(model.Image);

            // Add new ImageEntity that will have only string src and id
            // Change the ProductEntity ImageSrcPath property to be List<ImageEntity> Images
            // Change the request model ImageSrcProperty to List<ImageEntity> Images
            // In the product service change the add method => foreach method -> add the ImageEntity to the db and product.Images.Add(image.Id)
            // Or just add all the images inside the ImgSourcePath property and separate them by " ; "
            await this._productsService.AddProduct(product);

            return this.RedirectToAction("Index", "Home", new { area = "" });

            // For test purposes only
            //return this.View("Areas/Administration/Views/MenuItem/TestPurposesView.cshtml", menuItem);
        }
    }
}
