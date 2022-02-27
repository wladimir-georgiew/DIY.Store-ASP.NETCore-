using DIY.Castle.Data.Models;
using System.Collections.Generic;

namespace DIY.Castle.Web.Areas.Administration.Models
{
    public class EditProductModel : BaseProductModel
    {
        public EditProductModel()
        {

        }

        public EditProductModel(string name, string description, string category, List<Category> allCategories, string subcategory, List<Subcategory> allSubcategories)
        {
            base.Name = name;
            base.Description = description;
            base.Subcategory = subcategory;
            base.Category = category;
            base.AllCategories = allCategories;
            base.AllSubcategories = allSubcategories;
        }

        public int ProductId { get; set; }
    }
}
