using DIY.Castle.Data.Models;
using DIY.Castle.Web.Data;
using DIY.Castle.Web.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using AutoMapper;

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

        public IEnumerable<Product> GetAllProducts() => this._dbContext.Products;

        public IEnumerable<Product> GetProductsByType(string productTypeFilter)
        {
            bool isFilterValid = Enum.TryParse(productTypeFilter, out ProductTypeEnum enumFilter);

            if (string.IsNullOrEmpty(productTypeFilter) || !isFilterValid)
            {
                return this._dbContext.Products;
            }

            var products = this._dbContext.Products.Where(x => x.ProductType == (int)enumFilter);

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
            productModel.ProductType = GetProductType(product.ProductType);
            productModel.IsNewProduct = DateTime.UtcNow.Subtract(product.CreatedOn).TotalDays <= 7;

            return productModel;
        }

        private string GetProductType(int productType)
        {
            switch (productType)
            {
                case 0:
                    return "Неизвестни";
                case 1:
                    return "Стикери";
                case 2:
                    return "Разделители";
                case 3:
                    return "Свещи";
                case 4:
                    return "Картички";
                case 5:
                    return "Икони";
                default:
                    return "Няма тип";
            }
        }
    }
}
