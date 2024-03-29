﻿using DIY.Castle.Data.Models;
using DIY.Castle.Web.Data;
using DIY.Castle.Web.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using DIY.Castle.Web.Areas.Administration.Models;
using DIY.Castle.Web.Services.CategoriesService;
using DIY.Castle.Web.Services.UploadFileService;
using DIY.Castle.Web.Services.SubcategoriesService;

namespace DIY.Castle.Web.Services.ProductsService
{
    public class ProductsService : IProductsService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ICategoriesService categoriesService;
        private readonly ISubcategoriesService subCategoriesService;
        private readonly IUploadFileService uploadFileService;

        public ProductsService(ApplicationDbContext dbContext, IMapper mapper, ICategoriesService categoriesService, IUploadFileService uploadFileService, ISubcategoriesService subCategoriesService)
        {
            this._dbContext = dbContext;
            this._mapper = mapper;
            this.categoriesService = categoriesService;
            this.uploadFileService = uploadFileService;
            this.subCategoriesService = subCategoriesService;
        }

        public IEnumerable<Variation> GetAllVariations() => this._dbContext.Variations?.Include("Product");

        public IEnumerable<Variation> GetProductVariations(int productId) => this.GetAllVariations().Where(x => x.ProductId == productId);

        public Variation GetVariationById(int id) => this._dbContext.Variations?.Include("Product").FirstOrDefault(x => x.Id == id);

        public Product GetProductById(int id) => this._dbContext.Products?.Include("Variations").Include("Category").Include("Subcategory").FirstOrDefault(x => x.Id == id);

        public IEnumerable<Product> GetAllProducts() => this._dbContext.Products.Include("Category").Include("Subcategory").Include("Variations");

        public IEnumerable<Product> GetProductsByType(string productTypeFilter)
        {
            var products = this.GetAllProducts().Where(x => !string.IsNullOrEmpty(productTypeFilter) ? x.Category.Name == productTypeFilter : true);

            return products;
        }

        public IEnumerable<Product> GetProductsBySubcategory(string subcategory)
        {
            var products = this.GetAllProducts().Where(x => !string.IsNullOrEmpty(subcategory) ? x.Subcategory.Name == subcategory : true);

            return products;
        }

        public async Task AddProductAsync(Product product, Variation variation)
        {
            product.CreatedOn = DateTime.UtcNow;
            product.Variations.Add(variation);
            variation.Product = product;

            await this._dbContext.AddAsync(product);
            await this._dbContext.AddAsync(variation);
            await this._dbContext.SaveChangesAsync();
        }

        public List<string> GetProductImagesSrcPaths(int id)
        {
            var product = this.GetProductById(id);

            return product.ImageSourcePath.Split(';').ToList();
        }

        public ProductModel GetProductModel(Product product, int variationId = -1)
        {
            var productModel = new ProductModel
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                ProductType = product.Category.Name,
                Subcategory = product.Subcategory.Name,
                ImagesSourcePaths = this.GetProductImagesSrcPaths(product.Id),
                IsNewProduct = DateTime.UtcNow.Subtract(product.CreatedOn).TotalDays <= 7,
                ProductVariations = this.GetProductVariations(product.Id).OrderBy(x => x.Price).ToList(),
            };

            var productPrice = string.Empty;
            if (productModel.ProductVariations.Count == 1)
            {
                productPrice = productModel.ProductVariations.FirstOrDefault().Price.ToString();
            }
            else
            {
                var lowestPrice = productModel.ProductVariations.Select(x => x.Price).OrderBy(x => x).FirstOrDefault();
                var highestPrice = productModel.ProductVariations.Select(x => x.Price).OrderByDescending(x => x).FirstOrDefault();

                productPrice = $"{lowestPrice} - {highestPrice}";
            }
               

            productModel.Price = productPrice;

            return productModel;
        }
        public VariationProductModel GetProductVariationModel(Variation variation)
        {
            var productFamily = variation.Product;
            var variationsCount = this.GetProductById(productFamily.Id).Variations.Count();

            var variationProductModel = new VariationProductModel
            {
                Id = variation.Id,
                ProductId = productFamily.Id,
                ProductName = productFamily.Name,
                VariationName = variation.VariationName,
                Name = variationsCount == 1 ? productFamily.Name : $"{productFamily.Name} - {variation.VariationName}",
                Description = productFamily.Description,
                Price = variation.Price,
                ImagesSourcePaths = this.GetProductImagesSrcPaths(productFamily.Id),
                IsNewProduct = DateTime.UtcNow.Subtract(productFamily.CreatedOn).TotalDays <= 7,
                CreatedOn = productFamily.CreatedOn.ToString("d"),
            };

            return variationProductModel;
        }

        public async Task UpdateProductAsync(EditProductModel model)
        {
            var category = this.categoriesService.GetCategoryByName(model.Category);
            var subCategory = this.subCategoriesService.GetCategoryByName(model.Subcategory);

            var product = this.GetProductById(model.ProductId);

            product.Name = model.Name;
            product.Description = model.Description;
            product.Subcategory = subCategory;
            product.SubcategoryId = subCategory.Id;
            product.Category = category;
            product.CategoryId = category.Id;

            await this._dbContext.SaveChangesAsync();
        }

        public async Task DeleteProductAsync(int productId)
        {
            var product = this.GetProductById(productId);
            var variations = product.Variations;
            var productImagesPaths = product.ImageSourcePath
                .Split(';')
                .ToList()
                //Removes the " /images/ " string from the name
                .Select(x => x.Substring(8))
                .ToList();

            foreach (var variation in variations)
            {
                this._dbContext.Variations.Remove(variation);
            }

            this.uploadFileService.DeleteFiles(productImagesPaths);
            this._dbContext.Products.Remove(product);

            await this._dbContext.SaveChangesAsync();
        }

        public List<Product> GetRandomProducts(int count = 8) => this.GetAllProducts().OrderBy(x => Guid.NewGuid()).Take(count).ToList();

    }
}
