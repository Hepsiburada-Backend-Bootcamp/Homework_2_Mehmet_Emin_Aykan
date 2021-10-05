using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Domain.Entities
{
    public class Product
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Required")]
        [StringLength(50,MinimumLength =1,ErrorMessage ="Name should be between 1-50 characters")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Required")]
        public double Price { get; set; }

        [Required(ErrorMessage = "Required")]
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category CategoryName { get; set; }

        [Required(ErrorMessage = "Required")]
        [Range(0,int.MaxValue)]
        public int UnitsInStock { get; set; }

        [StringLength(100, MinimumLength = 0, ErrorMessage = "Name should be between 0-200 characters")]
        public string Description { get; set; }
    }
}
