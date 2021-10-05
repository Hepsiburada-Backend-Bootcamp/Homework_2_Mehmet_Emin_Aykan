using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Application.DTOs.UserDTOs;

namespace ECommerce.Application.IServices
{
    public interface IUserService
    {
        Task Add(CreateUserDTO user);

        Task Delete(int id);

        Task Update(int id,UpdateUserDTO user);

        Task<List<GetUserDTO>> GetAll();

        Task<List<GetUserDTO>> Get(Expression<Func<GetUserDTO,bool>> filter);
    }
}
