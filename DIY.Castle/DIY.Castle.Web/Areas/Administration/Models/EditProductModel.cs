using DIY.Castle.Data.Models;
using System.Collections.Generic;

namespace DIY.Castle.Web.Areas.Administration.Models
{
    public class EditProductModel : BaseProductModel
    {
        public EditProductModel()
        {

        }

        public EditProductModel(string name, string description, string category, List<Category> allCategories)
        {
            base.Name = name;
            base.Description = description;
            base.Category = category;
            base.AllCategories = allCategories;
        }

        public int ProductId { get; set; }
    }
}
