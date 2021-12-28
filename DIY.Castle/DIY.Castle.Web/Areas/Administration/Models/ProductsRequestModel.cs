using DIY.Castle.Common.Attributes;
using DIY.Castle.Data.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DIY.Castle.Web.Areas.Administration.Models
{
    public class ProductsRequestModel
    {
        public List<Category> Categories { get; set; }

        [Required(ErrorMessage = "Полето Име е задължително")]
        [MaxLength(50, ErrorMessage = "Дължината на името не може да надвишава 50 символа")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Полето Име на подпродукт е задължително")]
        public string VariationName { get; set; }

        [Required(ErrorMessage = "Полето Цена е заължително")]
        [Range(0.1, 10000.00, ErrorMessage = "Стойността на цената трябва да е между 0.10 и 10000.00")]
        public double Price { get; set; }

        [Required]
        public string ProductType { get; set; }

        [Required(ErrorMessage = "Полето Описание е задължително")]
        [MaxLength(490, ErrorMessage = "Дължината на описанието не може да надвишава 490 символа")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Задължително е да предоставите поне 1 снимка")]
        [DataType(DataType.Upload)]
        [AllowedExtensions(new[] { ".jpg", ".png" })]
        [MaxFileSize(3 * 1024 * 1024)] // 3mb
        public List<IFormFile> Images { get; set; }
    }
}
