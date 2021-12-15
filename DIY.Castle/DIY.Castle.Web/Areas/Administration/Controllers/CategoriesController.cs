using AutoMapper;
using DIY.Castle.Data.Models;
using DIY.Castle.Web.Areas.Administration.Models;
using DIY.Castle.Web.Services.CategoriesService;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIY.Castle.Web.Areas.Administration.Controllers
{
    public class CategoriesController : AdministrationController
    {
        private readonly ICategoriesService categoriesService;

        public CategoriesController(ICategoriesService categoriesService)
        {
            this.categoriesService = categoriesService;
        }

        [HttpGet]
        public IActionResult Create()
        {
            var categories = this.categoriesService.GetAllCategories().ToList();

            var model = new CategoryRequestModel();
            model.Categories = this.categoriesService.GetAllCategories().ToList();

            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Categories = this.categoriesService.GetAllCategories().ToList();
                return this.View(model);
            }

            var category = new Category()
            {
                Name = model.Name,
                CreatedOn = DateTime.UtcNow,
            };

            await this.categoriesService.AddCategory(category);

            return this.RedirectToAction("Index", "Home", new { area = "" });
        }

        //[HttpPatch("{id:int}")]
        [HttpPost]
        public async Task<IActionResult> Update(CategoryRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Categories = this.categoriesService.GetAllCategories().ToList();
                return this.View("../Views/Categories/Create");
            }

            await this.categoriesService.UpdateCategoryById(model.Id, model.Name);

            return this.RedirectToAction("Index", "Home", new { area = "" });
        }
    }
}
