using System.Collections.Generic;

namespace DIY.Castle.Web.Models
{
    public class VariationProductModel
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public string VariationName { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public List<string> ImagesSourcePaths { get; set; }

        public string CreatedOn { get; set; }

        public bool IsNewProduct { get; set; } = false;

        public decimal Price { get; set; }
    }
}
