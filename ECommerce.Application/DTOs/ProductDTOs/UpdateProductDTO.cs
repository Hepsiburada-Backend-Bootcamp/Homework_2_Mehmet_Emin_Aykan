using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.DTOs.ProductDTOs
{
    public class UpdateProductDTO
    {
        public string ProductName { get; set; }
        public double Price { get; set; }
        public int UnitsInStock { get; set; }
        public string Description { get; set; }
    }
}
