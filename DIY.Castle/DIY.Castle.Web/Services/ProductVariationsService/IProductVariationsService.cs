using DIY.Castle.Data.Models;
using DIY.Castle.Web.Areas.Administration.Models.Variations;
using System.Threading.Tasks;

namespace DIY.Castle.Web.Services.ProductVariationsService
{
    public interface IProductVariationsService
    {
        public Task CreateVariation(CreateVariationProductRequestModel model);

        public Task<Variation> EditVariation(EditVariationProductRequestModel model);

        public Task DeleteVariation(int id);

        public Task DeleteVariation(Variation variation);
    }
}
