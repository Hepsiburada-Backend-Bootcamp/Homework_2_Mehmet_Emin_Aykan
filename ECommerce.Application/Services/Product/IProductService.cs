using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Application.DTOs.ProductDTOs;

namespace ECommerce.Application.Services.Product
{
    public interface IProductService
    {
        Task Add(ProductDTO productDTO);

        Task Delete(int id);

        Task Update(int id, ProductDTO productDTO);

        List<ProductDTO> GetAll();

        Task<ProductDTO> GetById(int id);
    }
}
