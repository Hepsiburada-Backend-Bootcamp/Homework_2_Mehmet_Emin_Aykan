using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Application.DTOs.CustomerDTOs;

namespace ECommerce.Application.Services.Customer
{
    public interface ICustomerService
    {
        Task Add(CreateCustomerDTO customerDTO);

        Task Delete(int id);

        Task Update(int id, CreateCustomerDTO customerDTO);

        List<GetCustomerDTO> GetAll();

        Task<GetCustomerDTO> GetById(int id);
    }
}
