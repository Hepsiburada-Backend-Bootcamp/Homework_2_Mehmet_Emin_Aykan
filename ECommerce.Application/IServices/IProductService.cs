using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Application.DTOs.ProductDTOs;

namespace ECommerce.Application.IServices
{
    public interface IProductService
    {
        Task Add(CreateProductDTO product);
    }
}
