using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.DTOs.UserDTOs
{
    public class CreateUserDTO
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Emaıl { get; set; }
        public string Password { get; set; }

    }
}
