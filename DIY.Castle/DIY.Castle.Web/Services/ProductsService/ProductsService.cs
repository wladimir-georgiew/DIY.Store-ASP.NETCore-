using DIY.Castle.Data.Models;
using DIY.Castle.Web.Data;
using System.Collections.Generic;
using System.Linq;

namespace DIY.Castle.Web.Services.ProductsService
{
    public class ProductsService : IProductsService
    {
        private readonly ApplicationDbContext _dbContext;

        public ProductsService(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public Product GetProductById(int id) => this._dbContext.Products?.FirstOrDefault(x => x.Id == id);

        public IEnumerable<Product> GetAllProducts(int id) => this._dbContext.Products;
    }
}
