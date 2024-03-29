﻿using AutoMapper;
using DIY.Castle.Data.Models;
using DIY.Castle.Web.Areas.Administration.Models;
using DIY.Castle.Web.Models;
using DIY.Castle.Web.Models.ViewModels;
using System;
using System.Linq;

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
                .ForMember(x => x.Description, y => y.MapFrom(z => z.Description))
                .ForMember(x => x.CreatedOn, y => y.MapFrom(z => z.CreatedOn))
                .ForMember(x => x.ProductType, y => y.MapFrom(z => z.Category.Name))
                .ForMember(x => x.Subcategory, y => y.MapFrom(z => z.Subcategory.Name))
                .ForAllOtherMembers(x => x.Ignore());

            CreateMap<CreateProductModel, Product>()
               .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
                .ForMember(x => x.Description, y => y.MapFrom(z => z.Description))
                .ForMember(x => x.ImageSourcePath, y => y.Ignore())
                .ForMember(x => x.CreatedOn, y => y.MapFrom(z => DateTime.UtcNow))
                .ForAllOtherMembers(x => x.Ignore());

            CreateMap<CreateProductModel, Variation>()
               .ForMember(x => x.VariationName, y => y.MapFrom(z => z.VariationName))
               .ForMember(x => x.Price, y => y.MapFrom(z => z.Price))
                .ForMember(x => x.CreatedOn, y => y.MapFrom(z => DateTime.UtcNow))
                .ForAllOtherMembers(x => x.Ignore());

           
        }
    }
}
