using DIY.Castle.Data.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DIY.Castle.Web.Areas.Administration.Models
{
    public class BaseProductModel
    {
        public List<Category> AllCategories { get; set; }
        public List<Subcategory> AllSubcategories { get; set; }

        [Required(ErrorMessage = "Полето Име е задължително")]
        [MaxLength(50, ErrorMessage = "Дължината на името не може да надвишава 50 символа")]
        public string Name { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        public string Subcategory { get; set; }

        [Required(ErrorMessage = "Полето Описание е задължително")]
        [MaxLength(490, ErrorMessage = "Дължината на описанието не може да надвишава 490 символа")]
        public string Description { get; set; }
    }
}
