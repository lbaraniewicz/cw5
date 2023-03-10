using System.ComponentModel.DataAnnotations;

namespace cw5.Model
{
    public class Order
    {
        [Required]
        public int IdProduct { get; set; }
        [Required]
        public int IdOrder { get; set; }
        [Required]
        public int Amount { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        public DateTime? FullfilledAt { get; set; }
    }
}
