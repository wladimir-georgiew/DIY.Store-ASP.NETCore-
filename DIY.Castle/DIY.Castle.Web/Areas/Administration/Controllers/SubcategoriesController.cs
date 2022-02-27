using DIY.Castle.Data.Models;
using DIY.Castle.Web.Areas.Administration.Models;
using DIY.Castle.Web.Services.SubcategoriesService;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DIY.Castle.Web.Areas.Administration.Controllers
{
    public class SubcategoriesController : AdministrationController
    {
        private readonly ISubcategoriesService categoriesService;

        public SubcategoriesController(ISubcategoriesService categoriesService)
        {
            this.categoriesService = categoriesService;
        }

        [HttpGet]
        public IActionResult Create()
        {
            var categories = this.categoriesService.GetAllCategories().ToList();

            var model = new SubcategoryRequestModel();
            model.AllCategories = this.categoriesService.GetAllCategories().ToList();

            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(SubcategoryRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                model.AllCategories = this.categoriesService.GetAllCategories().ToList();
                return this.View(model);
            }

            var category = new Subcategory()
            {
                Name = model.Name,
                CreatedOn = DateTime.UtcNow,
            };

            await this.categoriesService.AddCategory(category);

            return this.RedirectToAction("Index", "Home", new { area = "" });
        }


        [HttpPost]
        public async Task<IActionResult> Update(SubcategoryRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                model.AllCategories = this.categoriesService.GetAllCategories().ToList();
                return this.View("../Views/Subcategories/Create");
            }

            await this.categoriesService.UpdateCategoryById(model.Id, model.Name);

            return this.RedirectToAction("Index", "Home", new { area = "" });
        }
    }
}
