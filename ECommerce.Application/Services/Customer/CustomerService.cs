using ECommerce.Application.DTOs.CustomerDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ECommerce.Domain.Repositories;

namespace ECommerce.Application.Services.Customer
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        public CustomerService(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task Add(CreateCustomerDTO customerDTO)
        {
            var enterCustomer = _mapper.Map<Domain.Entities.Customer>(customerDTO);
            var customer =  _customerRepository.Get(c => c.Name.Equals(enterCustomer.Name)&&c.LastName.Equals(enterCustomer.LastName)&&c.Email.Equals(enterCustomer.Email)).Result;
            if (customer.Equals(null))
            {
                await _customerRepository.Add(_mapper.Map<Domain.Entities.Customer>(customerDTO));
            }
            throw new Exception("Already exist");
            
        }

        public async Task Delete(int id)
        {
            var customer = _customerRepository.Get(c => c.Id == id).Result;
            if(customer.Equals(null))
            {
                throw new Exception("Not exist");
            }
            await _customerRepository.Delete(customer);
        }

        public async Task<GetCustomerDTO> GetById(int id)
        {
            var customer = await _customerRepository.Get(c => c.Id == id);
            return _mapper.Map<GetCustomerDTO>(customer);
        }

        public List<GetCustomerDTO> GetAll()
        {
            var customerList = _customerRepository.GetAll();
            return _mapper.Map<List<GetCustomerDTO>>(customerList);
        }

        public async Task Update(int id, CreateCustomerDTO customerDTO)
        {
            var customer = _customerRepository.Get(c => c.Id == id).Result;
            if (customer.Equals(null))
            {
                throw new Exception("Not exist");
            }
            var changed = _mapper.Map<Domain.Entities.Customer>(customerDTO);
            customer.Name = changed.Name;
            customer.LastName = changed.LastName;
            customer.Email = changed.Email;
            customer.Password = changed.Password;

            await _customerRepository.Update(customer);
        }
    }
}
