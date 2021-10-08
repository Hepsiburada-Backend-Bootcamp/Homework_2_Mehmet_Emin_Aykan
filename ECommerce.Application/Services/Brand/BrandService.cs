using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ECommerce.Application.DTOs.BrandDTOs;
using ECommerce.Domain.Repositories;

namespace ECommerce.Application.Services.Brand
{
    public class BrandService:IBrandService
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IMapper _mapper;
        public BrandService(IBrandRepository brandRepository, IMapper mapper)
        {
            _brandRepository = brandRepository;
            _mapper = mapper;
        }

        public async Task Add(BrandDTO brandDTO)
        {
            var entered = _mapper.Map<Domain.Entities.Brand>(brandDTO);
            var brand = _brandRepository.Get(c => c.BrandName .Equals(entered.BrandName)).Result;
            if (brand.Equals(null))
            {
                await _brandRepository.Add(_mapper.Map<Domain.Entities.Brand>(brandDTO));
            }
            throw new Exception("Already exist");
        }

        public async Task Delete(int id)
        {
            var brand = _brandRepository.Get(c => c.Id == id).Result;
            if (brand.Equals(null))
            {
                throw new Exception("Not exist");
            }
            await _brandRepository.Delete(brand);
        }

        public List<BrandDTO> GetAll()
        {
            var brandList = _brandRepository.GetAll();
            return _mapper.Map<List<BrandDTO>>(brandList);
        }

        public async Task<BrandDTO> GetById(int id)
        {
            var brand = await _brandRepository.Get(c => c.Id == id);
            return _mapper.Map<BrandDTO>(brand);
        }

        public async Task Update(int id, BrandDTO brandDTO)
        {
            var brand = _brandRepository.Get(c => c.Id == id).Result;
            if (brand.Equals(null))
            {
                throw new Exception("Not exist");
            }
            var changed = _mapper.Map<Domain.Entities.Brand>(brandDTO);
            brand.BrandName = changed.BrandName;

            await _brandRepository.Update(brand);
        }
    }
}
