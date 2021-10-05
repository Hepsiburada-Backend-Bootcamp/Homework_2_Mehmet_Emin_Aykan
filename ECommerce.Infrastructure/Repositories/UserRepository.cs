using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Repositories;
using ECommerce.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Infrastructure.Repositories
{
    public class UserRepository : Repository<User> , IUserRepository
    {
        private readonly ECommerceDbContext _context;
        public UserRepository(ECommerceDbContext dbContext):base(dbContext)
        {
            _context = dbContext;
        }

        public async Task<User> GetById(int id)
        {
            return await _context.Set<User>()
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == id);
        }

    }
}
