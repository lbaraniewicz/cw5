namespace cw5.Model
{
    public class Order
    {
        public int IdProduct { get; set; }

        public int IdWarehouse { get; set; }

        public int Amount { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? FullfilledAt { get; set; }
    }
}
