using System.Data.SqlClient;

namespace AddProduct
{
    public class Program
    {
        public static void Main()
        {
            AddProduct("Kifla");
            AddProduct("Milenka");
        }

        private static void AddProduct(string name)
        {
            SqlConnection dbCon = new SqlConnection("Server=.; Database=Northwind; Integrated Security=true");
            dbCon.Open();
            using (dbCon)
            {
                using (var cmd = new SqlCommand("INSERT INTO Products (ProductName) VALUES (@name)", dbCon))
                {
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
