using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Application.DTOs.BrandDTOs;

namespace ECommerce.Application.Services.Brand
{
    public interface IBrandService
    {
        Task Add(BrandDTO brandDTO);

        Task Delete(int id);

        Task Update(int id, BrandDTO brandDTO);

        List<BrandDTO> GetAll();

        Task<BrandDTO> GetById(int id);
    }
}
