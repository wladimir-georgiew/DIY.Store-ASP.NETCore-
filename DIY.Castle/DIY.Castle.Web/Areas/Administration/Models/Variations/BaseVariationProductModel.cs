using System;
using System.ComponentModel.DataAnnotations;

namespace DIY.Castle.Web.Areas.Administration.Models.Variations
{
    public class BaseVariationProductModel
    {
        [Required(ErrorMessage = "Полето Име е задължително")]
        [MaxLength(150, ErrorMessage = "Полето Име не може да съдържа повече от 150 символа")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Полето Цена е задължително")]
        [Range(0.00, 100000.00, ErrorMessage = "Цената трябва да варира между 0.00 - 100000.00 лв.")]
        public decimal Price { get; set; }
    }
}
