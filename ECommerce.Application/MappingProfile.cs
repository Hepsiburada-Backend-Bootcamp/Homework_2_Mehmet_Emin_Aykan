using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ECommerce.Application.DTOs.OrderDTOs;
using ECommerce.Application.DTOs.ProductDTOs;
using ECommerce.Application.DTOs.UserDTOs;

namespace ECommerce.Application
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateUserDTO, Domain.Entities.User>().ReverseMap();

            CreateMap<Domain.Entities.User, GetUserDTO>();

            CreateMap<UpdateUserDTO, Domain.Entities.User>().ReverseMap();

            CreateMap<CreateProductDTO, Domain.Entities.Product>().ReverseMap();

            CreateMap<UpdateProductDTO, Domain.Entities.Product>().ReverseMap();

            CreateMap<GetOrderDTO, Domain.Entities.Order>().ReverseMap();
        }
    }
}
