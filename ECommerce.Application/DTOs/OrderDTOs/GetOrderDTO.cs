using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.DTOs.OrderDTOs
{
    public class GetOrderDTO
    {
        public int OrderNumber { get; set; }
        public double TotalPrice { get; set; }
        public string Adress { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
