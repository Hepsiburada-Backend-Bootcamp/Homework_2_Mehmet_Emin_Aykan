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
    public class ProductRepository:Repository<Product>,IProductRepository
    {
        private readonly ECommerceDbContext _context;
        public ProductRepository(ECommerceDbContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }

        public async Task<List<Product>> GetByCategoryId(int id)
        {
            List<Product> list=new List<Product>();
             list.Add(await _context.Set<Product>()
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.CategoryId == id));
             return list;
        }
    }
}
