using DIY.Castle.Data.Models;
using System.Collections.Generic;

namespace DIY.Castle.Web.Models
{
    public class ProductModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ProductType { get; set; }

        public string Subcategory { get; set; }

        // The price of the variation ( if the product has only 1 variation ) or the ({minimum variation price} - {maximum variation price})
        public string Price { get; set; }

        public string Description { get; set; }

        public List<string> ImagesSourcePaths { get; set; }

        public string CreatedOn { get; set; }

        public bool IsNewProduct { get; set; } = false;

        public List<Variation> ProductVariations { get; set; }
    }
}
