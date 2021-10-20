using DIY.Castle.Common.Attributes;
using DIY.Castle.Web.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DIY.Castle.Web.Areas.Administration.Models
{
    public class ProductsRequestModel
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Range(0.1, 10000.00, ErrorMessage = "Price should be between 0.10 and 10000.00")]
        public double Price { get; set; }

        [Required]
        public int ProductType { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [MaxLength(300, ErrorMessage = "Description max length is 300 characters")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Image is required")]
        [Display(Name = "Icon Image")]
        [DataType(DataType.Upload)]
        [AllowedExtensions(new[] { ".jpg", ".png" })]
        [MaxFileSize(3 * 1024 * 1024)] // 3mb
        public List<IFormFile> Images { get; set; }
    }
}
