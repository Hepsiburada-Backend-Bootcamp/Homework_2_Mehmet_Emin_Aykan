using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Application.DTOs.OrderDTOs;

namespace ECommerce.Application.DTOs.UserDTOs
{
    public class GetUserDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Emaıl { get; set; }
        public List<GetOrderDTO> Orders { get; set; }
    }
}
