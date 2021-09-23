using DIY.Castle.Common.Attributes;
using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace DIY.Castle.Web.Areas.Administration.Models
{
    public class ProductsRequestModel
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Range(0.1, 10.000, ErrorMessage = "Price should be between 0.10 and 10.000")]
        public double Price { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [MaxLength(300, ErrorMessage = "Description max length is 300 characters")]
        public string Description { get; set; }

        [Display(Name = "Icon Image")]
        [DataType(DataType.Upload)]
        [AllowedExtensions(new[] { ".jpg", ".png" })]
        [MaxFileSize(3 * 1024 * 1024)] // 3mb
        public IFormFile Image { get; set; }
    }
}
