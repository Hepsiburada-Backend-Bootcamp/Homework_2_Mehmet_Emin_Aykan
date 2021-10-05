using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ECommerce.Application.DTOs.UserDTOs;
using ECommerce.Application.IServices;
using ECommerce.Domain.Repositories;

namespace ECommerce.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public Task Add(CreateUserDTO user)
        {
            return _userRepository.Add(_mapper.Map<Domain.Entities.User>(user));
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<GetUserDTO>> Get(Expression<Func<GetUserDTO, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public async Task<List<GetUserDTO>> GetAll()
        {
            var userList=await _userRepository.GetAll();
            return _mapper.Map<List<GetUserDTO>>(userList);
            
        }

        public Task Update(int id, UpdateUserDTO user)
        {
            throw new NotImplementedException();
        }
    }
}
