using cw5.Model;

namespace cw5.Services
{
    public interface IProductService
    {
        int DeleteOrder(int id);
        IEnumerable<Order> GetOrder(int id);
        int CheckOrder(OrderDto order);
        IEnumerable<Product> GetProduct(int id);
        IEnumerable<Warehouse> GetWarehouse(int id);
        int InsertOrder(OrderDto newOrder, int idOrder);
        int UpdateOrder(OrderDto value, int idOrder);
        bool CheckOrderExists(int idOrder);
        public void UpdateOrderDate(int idOrder);
    }
}
