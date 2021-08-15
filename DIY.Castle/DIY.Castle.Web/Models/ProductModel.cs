using System;
using System.Collections.Generic;
namespace DIY.Castle.Web.Models
{
    public class ProductModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public string ImageSourcePath { get; set; }

        public string CreatedOn { get; set; }
    }
}
