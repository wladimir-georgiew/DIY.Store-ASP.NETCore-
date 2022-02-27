using DIY.Castle.Data.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DIY.Castle.Web.Areas.Administration.Models
{
    public class SubcategoryRequestModel
    {
        [Required]
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Subcategory> AllCategories { get; set; }
    }
}
