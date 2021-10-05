using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Domain.Entities
{
    public class OrderItem
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Required")]
        public Guid OrderId { get; set; }

        [ForeignKey("OrderId")]
        public virtual Order Order { get; set; }

        [Required(ErrorMessage = "Required")]
        public Guid ProductId { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }

        [Range(0, int.MaxValue)]
        [Required(ErrorMessage = "Required")]
        public int Piece { get; set; }

        [Required(ErrorMessage = "Required")]
        [Range(0, double.MaxValue)]
        public double ItemPrice { get; set; }
    }
}
