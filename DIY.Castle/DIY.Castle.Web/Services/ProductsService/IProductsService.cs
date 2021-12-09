using DIY.Castle.Data.Models;
using DIY.Castle.Web.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DIY.Castle.Web.Services.ProductsService
{
    public interface IProductsService
    {
        Product GetProductById(int id);

        IEnumerable<Product> GetAllProducts();

        IEnumerable<Product> GetProductsByType(string productTypeFilter);

        Task AddProduct(Product product);

        List<string> GetProductImagesSrcPaths(int id);

        ProductModel GetProductModel(Product product);
    }
}
