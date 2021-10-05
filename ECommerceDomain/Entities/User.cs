using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ECommerce.Domain.Entities;

namespace ECommerce.Domain.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Required")]
        [StringLength(50,MinimumLength =1,ErrorMessage ="Name should be between 1-50 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Required")]
        [StringLength(50,MinimumLength =1,ErrorMessage ="Name should be between 1-50 characters")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Required")]
        [RegularExpression(@"\b[A-Z0-9._%-]+@[A-Z0-9.-]+\.[A-Z]{2,4}\b")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Required")]
        [RegularExpression(@"^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[*.!@$%^&(){}[]:;<>,.?/~_+-=|\]).{8,32}$")]
        public string Password { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
