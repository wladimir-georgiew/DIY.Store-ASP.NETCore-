using DIY.Castle.Data.Models;
using DIY.Castle.Web.Areas.Administration.Models;
using DIY.Castle.Web.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIY.Castle.Web.Services.ProductsService
{
    public interface IProductsService
    {
        public Task UpdateProductAsync(EditProductModel model);

        Product GetProductById(int id);

        IEnumerable<Product> GetAllProducts();

        IEnumerable<Product> GetProductsByType(string productTypeFilter);

        Task AddProductAsync(Product product, Variation variation);

        IEnumerable<Variation> GetAllVariations();

        IEnumerable<Variation> GetProductVariations(int productId);

        Variation GetVariationById(int id);

        List<string> GetProductImagesSrcPaths(int id);

        ProductModel GetProductModel(Product product, int variationId = -1);

        VariationProductModel GetProductVariationModel(Variation variation);

        public Task DeleteProductAsync(int productId);

        public List<Product> GetRandomProducts(int count = 8);
    }
}
