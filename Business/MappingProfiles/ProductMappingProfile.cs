using AutoMapper;
using Business.DTOs.Product.Request;
using Business.DTOs.Product.Response;
using Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.MappingProfiles
{
    public class ProductMappingProfile : Profile
    {
        public ProductMappingProfile()
        {
            CreateMap<ProductCreateDTO, Product>();

            CreateMap<Product, ProductDTO>();

            CreateMap<ProductUpdateDTO, Product>();
        }
    }
}
