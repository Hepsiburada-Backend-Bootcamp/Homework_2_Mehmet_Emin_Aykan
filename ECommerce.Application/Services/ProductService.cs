using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ECommerce.Application.DTOs.ProductDTOs;
using ECommerce.Application.IServices;
using ECommerce.Domain.Repositories;

namespace ECommerce.Application.Services
{
    public class ProductService:IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public Task Add(CreateProductDTO product)
        {
            return _productRepository.Add(_mapper.Map<Domain.Entities.Product>(product));
        }
    }
}
