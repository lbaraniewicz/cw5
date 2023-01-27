using System.ComponentModel.DataAnnotations;

namespace cw5.Model
{
    public class OrderDto
    {
        [Required]
        public int IdProduct { get; set; }
        [Required]
        public int IdWarehouse { get; set; }
        [Required]
        public int Amount { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
    }
}
