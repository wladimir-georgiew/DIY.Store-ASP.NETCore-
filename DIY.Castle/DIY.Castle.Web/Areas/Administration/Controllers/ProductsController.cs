﻿using AutoMapper;
using DIY.Castle.Data.Models;
using DIY.Castle.Web.Areas.Administration.Models;
using DIY.Castle.Web.Models;
using DIY.Castle.Web.Services.CategoriesService;
using DIY.Castle.Web.Services.ProductsService;
using DIY.Castle.Web.Services.SubcategoriesService;
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
        private readonly ICategoriesService _categoriesService;
        private readonly ISubcategoriesService _subCategoriesService;

        public ProductsController(IMapper mapper, IUploadFileService uploadFileService, IProductsService productsService, ICategoriesService categoriesService, ISubcategoriesService subCategoriesService)
        {
            this._mapper = mapper;
            this._uploadFileService = uploadFileService;
            this._productsService = productsService;
            this._categoriesService = categoriesService;
            this._subCategoriesService = subCategoriesService;
        }

        [HttpGet]
        public IActionResult Create()
        {
            var categories = _categoriesService.GetAllCategories().ToList();
            var subcategories = _subCategoriesService.GetAllCategories().ToList();
            var model = new CreateProductModel() { Categories = categories, Subcategories = subcategories };
            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductModel model)
        {
            if (!this.ModelState.IsValid)
            {
                model.Categories = _categoriesService.GetAllCategories().ToList();
                model.Subcategories = _subCategoriesService.GetAllCategories().ToList();
                return this.View(model);
            }

            var variation = this._mapper.Map<CreateProductModel, Variation>(model);
            var product = this._mapper.Map<CreateProductModel, Product>(model);

            var productImgSourcePaths = string.Empty;

            var imgIndex = 0;
            foreach (var img in model.Images)
            {
                var imgSeparator = imgIndex != 0 ? CommonConstants.ImageSeparator : string.Empty;
                productImgSourcePaths += (imgSeparator + this._uploadFileService.UploadFile(img));

                imgIndex++;
            }

            product.Category = this._categoriesService.GetCategoryByName(model.Category);
            product.Subcategory = this._subCategoriesService.GetCategoryByName(model.Subcategory);
            product.ImageSourcePath = productImgSourcePaths;
            await this._productsService.AddProductAsync(product, variation);

            return this.RedirectToAction("Index", "Home", new { area = "" });
        }

        [HttpGet]
        public IActionResult Edit(int productId)
        {
            var allCategories = this._categoriesService.GetAllCategories().ToList();
            var allSubcategories = _subCategoriesService.GetAllCategories().ToList();
            var product = this._productsService.GetProductById(productId);

            var vm = new EditProductModel(product.Name, product.Description, product.Category.Name, allCategories, product.Subcategory.Name, allSubcategories);
            vm.ProductId = product.Id;

            return this.View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditProductModel model)
        {
            if (!this.ModelState.IsValid)
            {
                model.AllCategories = _categoriesService.GetAllCategories().ToList();
                model.AllSubcategories = _subCategoriesService.GetAllCategories().ToList();
                return this.View(model);
            }

            await this._productsService.UpdateProductAsync(model);

            return this.RedirectToAction("Product", "ProductDetails", new { area = "", id = model.ProductId });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int productId)
        {
            // Deletes the product and his variations
            await this._productsService.DeleteProductAsync(productId);

            return this.RedirectToAction("Index", "Home", new { area = "" });
        }

        //[HttpPost]
        //public async Task<IActionResult> AddVariation(int productId)
        //{
            
        //}
    }
}
