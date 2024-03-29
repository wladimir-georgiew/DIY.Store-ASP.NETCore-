﻿using DIY.Castle.Common;
using DIY.Castle.Data.Models;
using DIY.Castle.Web.Models;
using DIY.Castle.Web.Services.ProductsService;
using DIY.Castle.Web.Services.SubcategoriesService;
using Microsoft.AspNetCore.Mvc;
using System;
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

        public IActionResult Index(string filter = null, int page = 1, string searchQuery = "", string subCategory = "")
        {
            if (subCategory != null &&
                !string.IsNullOrEmpty(subCategory))
            {
                var prodModels = this.productsService
             .GetProductsBySubcategory(subCategory)
             .OrderByDescending(x => x.CreatedOn)
             .Select(x => this.productsService.GetProductModel(x))
             .ToList();

                var vm = PaginationList<ProductModel>.Create(prodModels, page, 12);
                return View(vm);
            }

            // Prevents from getting an error when clicking the search button with empty input ( ?searchQuery= )
            if (searchQuery is null)
            {
                searchQuery = string.Empty;
            }

            var isQueryNull = string.IsNullOrEmpty(searchQuery);
            var searchQueryLower = !isQueryNull ? searchQuery.ToLower() : searchQuery;

            Func<Product, bool> filterByStartsWith = (x) => !isQueryNull ?
            x.Name.ToLower().StartsWith(searchQueryLower) : true;

            Func<Product, bool> filterByStartsWithAndContains = (x) => !isQueryNull ?
            x.Name.ToLower().StartsWith(searchQueryLower) ||
            x.Name.ToLower().Contains(searchQueryLower) ||
            x.Subcategory.Name.ToLower().Contains(searchQueryLower) : true;

            var productModels = this.productsService
                .GetProductsByType(filter)
                .Where(searchQuery.Length < 5 ? filterByStartsWith : filterByStartsWithAndContains)
                .OrderByDescending(x => x.CreatedOn)
                //.Select(x => this.productsService.GetProductModel(x))
                .Select(x => this.productsService.GetProductModel(x))
                .ToList();

            var viewModel = PaginationList<ProductModel>.Create(productModels, page, 12);
            return View(viewModel);
        }

        //public IActionResult FilteredBySubcategory(string subcategory, int page = 1)
        //{
        //    var productModels = this.productsService
        //       .GetProductsBySubcategory(subcategory)
        //       .Select(x => this.productsService.GetProductModel(x))
        //       .OrderByDescending(x => x.CreatedOn)
        //       .ToList();

        //    var viewModel = PaginationList<ProductModel>.Create(productModels, page, 12);
        //    return View("/Views/Catalog/Index.cshtml", viewModel);
        //}
    }
}
