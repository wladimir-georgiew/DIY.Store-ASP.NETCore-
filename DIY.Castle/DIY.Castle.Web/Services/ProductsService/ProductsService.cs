using DIY.Castle.Data.Models;
using DIY.Castle.Web.Data;
using DIY.Castle.Web.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace DIY.Castle.Web.Services.ProductsService
{
    public class ProductsService : IProductsService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public ProductsService(ApplicationDbContext dbContext, IMapper mapper)
        {
            this._dbContext = dbContext;
            this._mapper = mapper;
        }

        public Product GetProductById(int id) => this._dbContext.Products?.FirstOrDefault(x => x.Id == id);

        public IEnumerable<Product> GetAllProducts() => this._dbContext.Products.Include("Category");

        public IEnumerable<Product> GetProductsByType(string productTypeFilter)
        {
            var products = this.GetAllProducts().Where(x => !string.IsNullOrEmpty(productTypeFilter) ? x.Category.Name == productTypeFilter : true);

            return products;
        }

        public async Task AddProduct(Product product)
        {
            product.CreatedOn = DateTime.UtcNow;
            await this._dbContext.AddAsync(product);
            await this._dbContext.SaveChangesAsync();
        }

        public List<string> GetProductImagesSrcPaths(int id)
        {
            var product = this.GetProductById(id);

            return product.ImageSourcePath.Split(';').ToList();
        }

        public ProductModel GetProductModel(Product product)
        {
            var productModel = this._mapper.Map<ProductModel>(product);
            productModel.ImagesSourcePaths = this.GetProductImagesSrcPaths(product.Id);
            productModel.IsNewProduct = DateTime.UtcNow.Subtract(product.CreatedOn).TotalDays <= 7;

            return productModel;
        }
    }
}
