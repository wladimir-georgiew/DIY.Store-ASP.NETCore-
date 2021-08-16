using DIY.Castle.Data.Models;
using DIY.Castle.Web.Models;
using System.Collections.Generic;

namespace DIY.Castle.Web.Services.ProductsService
{
    public interface IProductsService
    {
        Product GetProductById(int id);

        IEnumerable<Product> GetAllProducts(int id);

        IEnumerable<ProductModel> GetLatestProducts();
    }
}
