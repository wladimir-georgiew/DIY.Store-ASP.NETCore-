using System.Collections.Generic;

namespace DIY.Castle.Web.Models.ViewModels
{
    public class CartViewModel
    {
        public List<ProductCartModel> Cart { get; set; }

        public decimal TotalPrice { get; set; }
    }

    public class ProductCartModel
    {
        public int Quantity { get; set; }

        public ProductModel Product { get; set; }
    }
}
