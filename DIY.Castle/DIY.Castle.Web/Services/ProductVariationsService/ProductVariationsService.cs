using DIY.Castle.Data.Models;
using DIY.Castle.Web.Areas.Administration.Models.Variations;
using DIY.Castle.Web.Data;
using DIY.Castle.Web.Services.ProductsService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIY.Castle.Web.Services.ProductVariationsService
{
    public class ProductVariationsService : IProductVariationsService
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IProductsService productsService;

        public ProductVariationsService(ApplicationDbContext dbContext, IProductsService productsService)
        {
            this.dbContext = dbContext;
            this.productsService = productsService;
        }

        public async Task CreateVariation(CreateVariationProductRequestModel model)
        {
            var variation = new Variation
            {
                CreatedOn = DateTime.UtcNow,
                VariationName = model.Name,
                Price = model.Price,
                ProductId = model.ProductId,
            };

            await this.dbContext.Variations.AddAsync(variation);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task<Variation> EditVariation(EditVariationProductRequestModel model)
        {
            var variation = this.productsService.GetVariationById(model.VariationId);

            variation.VariationName = model.Name;
            variation.Price = model.Price;

            await this.dbContext.SaveChangesAsync();

            return variation;
        }

        public async Task DeleteVariation(int id)
        {
            var variation = this.productsService.GetVariationById(id);
            await this.DeleteVariation(variation);
        }

        public async Task DeleteVariation(Variation variation)
        {
            this.dbContext.Variations.Remove(variation);
            await this.dbContext.SaveChangesAsync();
        }
    }
}
