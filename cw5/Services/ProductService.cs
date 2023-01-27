using cw5.Model;
using System.Data.SqlClient;

namespace cw5.Services
{
    public class ProductService
    {
        private const string ConString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=cw5;Trusted_Connection=True;";

        public IEnumerable<Order> GetAnimals()
        {
            using SqlConnection con = new SqlConnection(ConString);
            using SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from Animal";

            con.Open();

            var dr = cmd.ExecuteReader();
            var list = new List<Order>();
            while (dr.Read())
            {
                list.Add(new Order
                {
                    //IdAnimal = (int)dr["IdAnimal"],
                    //Name = dr["Name"].ToString(),
                });
            }

            return list;
        }

        //public int InsertAnimal(Animal newAnimal)
        //{
        //    using SqlConnection con = new SqlConnection(ConString);
        //    using SqlCommand cmd = new SqlCommand();
        //    cmd.Connection = con;
        //    cmd.CommandText = "insert into Animal(Name,Area,Category,Description) values (@Name,@Area,@Category,@Description)";
        //    cmd.Parameters.AddWithValue("@Name", newAnimal.Name);
        //    cmd.Parameters.AddWithValue("@Area", newAnimal.Area);
        //    cmd.Parameters.AddWithValue("@Category", newAnimal.Area);
        //    cmd.Parameters.AddWithValue("@Description", newAnimal.Description);

        //    con.Open();
        //    var rowsAffected = cmd.ExecuteNonQuery();
        //    return rowsAffected;
        //}

        //public int UpdateAnimal(Animal value, int idAnimal)
        //{
        //    using SqlConnection con = new SqlConnection(ConString);
        //    using SqlCommand cmd = new SqlCommand();
        //    cmd.Connection = con;
        //    cmd.CommandText = "update Animal set Name=@Name,Area=@Area,Category=@Category,Description=@Description where IdAnimal= @IdAnimal";
        //    cmd.Parameters.AddWithValue("@Name", value.Name);
        //    cmd.Parameters.AddWithValue("@Area", value.Area);
        //    cmd.Parameters.AddWithValue("@Category", value.Area);
        //    cmd.Parameters.AddWithValue("@Description", value.Description);
        //    cmd.Parameters.AddWithValue("@IdAnimal", idAnimal);

        //    con.Open();
        //    var rowsAffected = cmd.ExecuteNonQuery();
        //    return rowsAffected;
        //}

        //public int DeleteAnimal(int id)
        //{
        //    using SqlConnection con = new SqlConnection(ConString);
        //    using SqlCommand cmd = new SqlCommand();
        //    cmd.Connection = con;
        //    cmd.CommandText = "delete from Animal where IdAnimal= @IdAnimal";
        //    cmd.Parameters.AddWithValue("@IdAnimal", id);
        //    con.Open();
        //    var rowsAffected = cmd.ExecuteNonQuery();
        //    return rowsAffected;
        //}
    }
}
