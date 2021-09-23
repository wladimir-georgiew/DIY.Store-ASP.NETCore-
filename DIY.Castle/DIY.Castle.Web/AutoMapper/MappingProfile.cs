using AutoMapper;
using DIY.Castle.Data.Models;
using DIY.Castle.Web.Areas.Administration.Models;
using DIY.Castle.Web.Models;

namespace DIY.Castle.Web.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects

            // From Product to ProductModel
            CreateMap<Product, ProductModel>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
                .ForMember(x => x.Price, y => y.MapFrom(z => z.Price))
                .ForMember(x => x.Description, y => y.MapFrom(z => z.Description))
                .ForMember(x => x.ImageSourcePath, y => y.MapFrom(z => z.ImageSourcePath))
                .ForMember(x => x.CreatedOn, y => y.MapFrom(z => z.CreatedOn))
                .ForAllOtherMembers(x => x.Ignore());

            CreateMap<ProductsRequestModel, Product>()
               .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
                .ForMember(x => x.Price, y => y.MapFrom(z => z.Price))
                .ForMember(x => x.Description, y => y.MapFrom(z => z.Description))
                .ForMember(x => x.ImageSourcePath, y => y.Ignore())
                .ForAllOtherMembers(x => x.Ignore());
        }
    }
}
