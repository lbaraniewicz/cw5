using cw5.Model;
using System.Data.SqlClient;

namespace cw5.Services
{
    public class ProductService : IProductService
    {
        private const string ConString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=cw5;Trusted_Connection=True;";

        public int CheckOrder(OrderDto order)
        {
            using SqlConnection con = new SqlConnection(ConString);
            using SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = $"select IdOrder from Order where IdProduct={order.IdProduct} and Amount={order.Amount} and CreatedAt<'{order.CreatedAt}'";

            con.Open();

            var dr = cmd.ExecuteReader();
            int? idOrder = 0;
            while (dr.Read())
            {
                idOrder = (int?)dr["IdOrder"];
            }
            if (idOrder != null) return (int)idOrder;
            else return 0;
        }

        public int DeleteOrder(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetProduct(int id)
        {
            using SqlConnection con = new SqlConnection(ConString);
            using SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = $"select * from Product where IdProduct={id}";

            con.Open();

            var dr = cmd.ExecuteReader();
            var list = new List<Product>();
            while (dr.Read())
            {
                list.Add(new Product
                {
                    IdProduct = (int)dr["IdProduct"],
                    Name = (string)dr["Name"],
                    Description = (string)dr["Description"],
                    Price = (decimal)dr["Price"]
                });
            }
            return list;
        }

        public IEnumerable<Warehouse> GetWarehouse(int id)
        {
            using SqlConnection con = new SqlConnection(ConString);
            using SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = $"select * from Warehouse where IdWarehouse={id}";

            con.Open();

            var dr = cmd.ExecuteReader();
            var list = new List<Warehouse>();
            while (dr.Read())
            {
                list.Add(new Warehouse
                {
                    IdWarehouse = (int)dr["IdWarehouse"],
                    Name = (string)dr["Name"],
                    Address = (string)dr["Address"],
                });
            }
            return list;
        }

        public int InsertOrder(OrderDto newOrder, int idOrder)
        {
            using SqlConnection con = new SqlConnection(ConString);
            using SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = $"SELECT price from Product where IdProduct={newOrder.IdProduct}";
            con.Open();
            var dr = cmd.ExecuteReader();
            decimal price = (decimal)dr["price"];
            cmd.CommandText = $"INSERT INTO Product_Warehouse([IdWarehouse],[IdProduct],[IdOrder],[Amount],[Price],[CreatedAt]) " +
                $" OUTPUT inserted.IdProductWarehouse VALUES({newOrder.IdWarehouse},{newOrder.IdProduct},{idOrder},{newOrder.Amount},{(decimal)newOrder.Amount * price},'{DateTime.Now}')";
            int id = 0;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                id = (int)dr["IdProductWarehouse"];
            }
            return id;
        }

        public int UpdateOrder(OrderDto value, int idOrder)
        {
            throw new NotImplementedException();
        }

        public bool CheckOrderExists(int idOrder)
        {
            using SqlConnection con = new SqlConnection(ConString);
            using SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = $"select COUNT(1) as liczba from Order where IdOrder={idOrder}";

            con.Open();

            var dr = cmd.ExecuteReader();
            int? ifExist = 0;
            while (dr.Read())
            {
                ifExist = (int?)dr["liczba"];
            }
            if (ifExist != null) return true;
            else return false;
        }

        IEnumerable<Order> IProductService.GetOrder(int id)
        {
            using SqlConnection con = new SqlConnection(ConString);
            using SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = $"select * from Order where IdOrder={id}";

            con.Open();

            var dr = cmd.ExecuteReader();
            var list = new List<Order>();
            while (dr.Read())
            {
                list.Add(new Order
                {
                    IdProduct = (int)dr["IdProduct"],
                    IdOrder = (int)dr["IdOrder"],
                    Amount = (int)dr["Amount"],
                    CreatedAt = (DateTime)dr["CreatedAt"],
                    FullfilledAt = (DateTime)dr["FulfilledAt"]
                });
            }
            return list;
        }

        public void UpdateOrderDate(int idOrder)
        {
            using SqlConnection con = new SqlConnection(ConString);
            using SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = $"UPDATE ORDER SET FulfilledAt='{DateTime.Now}' where IdOrder={idOrder}";

            con.Open();

            var dr = cmd.ExecuteNonQuery();
        }
    }
}
