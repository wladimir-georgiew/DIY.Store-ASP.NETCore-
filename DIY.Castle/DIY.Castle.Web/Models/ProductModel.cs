using System;
using System.Collections.Generic;
namespace DIY.Castle.Web.Models
{
    public class ProductModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ProductType { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public List<string> ImagesSourcePaths { get; set; }

        public string CreatedOn { get; set; }

        public bool IsNewProduct { get; set; } = false;
    }
}
