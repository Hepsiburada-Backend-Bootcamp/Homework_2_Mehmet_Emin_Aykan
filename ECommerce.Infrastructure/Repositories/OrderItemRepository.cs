using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Repositories;
using ECommerce.Infrastructure.Context;

namespace ECommerce.Infrastructure.Repositories
{
    public class OrderItemRepository:Repository<OrderItem>,IOrderItemRepository
    {
        private readonly ECommerceDbContext _context;
        public OrderItemRepository(ECommerceDbContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }

    }
}
