using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Domain.Entities
{
    public class Order
    {
        [Key]
        public Guid Id { get; set; }

        [RegularExpression(@"[1-9]{4}-[0-9]{4}")]
        public int OrderNumber { get; set; }

        [Required(ErrorMessage = "Required")]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        [Required(ErrorMessage = "Required")]
        public double TotalPrice { get; set; }

        [Required(ErrorMessage = "Required")]
        public string Adress { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public virtual ICollection<OrderItem> OrderItems { get; set; }

    }
}
