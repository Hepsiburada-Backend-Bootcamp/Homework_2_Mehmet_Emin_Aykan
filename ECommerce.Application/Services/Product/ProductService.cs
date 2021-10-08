using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ECommerce.Application.DTOs.CategoryDTOs;
using ECommerce.Application.DTOs.ProductDTOs;
using ECommerce.Domain.Repositories;

namespace ECommerce.Application.Services.Product
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task Add(ProductDTO productDTO)
        {
            var entered = _mapper.Map<Domain.Entities.Product>(productDTO);
            var product = _productRepository.Get(p => p.ProductName.Equals(productDTO.ProductName) && p.BrandId == productDTO.BrandId).Result;
            if (product.Equals(null))
            {
                await _productRepository.Add(_mapper.Map<Domain.Entities.Product>(productDTO));
            }

            product.UnitsInStock++;
        }

        public async Task Delete(int id)
        {
            var entity = _productRepository.Get(c => c.Id == id).Result;
            if (entity.Equals(null))
            {
                throw new Exception("This customer not exist");
            }
            else
            {
                if (entity.UnitsInStock == 0)
                {
                    await _productRepository.Delete(entity);
                }
                else
                {
                    entity.UnitsInStock--;
                }
            }



        }

        public List<ProductDTO> GetAll()
        {
            var list = _productRepository.GetAll();
            return _mapper.Map<List<ProductDTO>>(list);
        }

        public async Task<ProductDTO> GetById(int id)
        {
            var entity = await _productRepository.Get(c => c.Id == id);
            return _mapper.Map<ProductDTO>(entity);
        }

        public async Task Update(int id, ProductDTO productDTO)
        {
            var entity = _productRepository.Get(c => c.Id == id).Result;
            if (entity.Equals(null))
            {
                throw new Exception("This customer not exist");
            }
            var changed = _mapper.Map<Domain.Entities.Product>(productDTO);
            entity.ProductName = changed.ProductName;
            entity.BrandId = changed.BrandId;
            entity.CategoryId = changed.CategoryId;
            entity.Price = changed.Price;
            entity.UnitsInStock = changed.UnitsInStock;

            await _productRepository.Update(entity);
        }
    }
}
