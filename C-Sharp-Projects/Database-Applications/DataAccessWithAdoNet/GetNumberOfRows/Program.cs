using System;
using System.Data.SqlClient;

namespace GetNumberOfRows
{
    public class Program
    {
        public static void Main()
        {
            SqlConnection dbCon = new SqlConnection("Server=.; Database=Northwind; Integrated Security=true");
            dbCon.Open();
            using (dbCon)
            {
                SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM Categories", dbCon);
                int count = (int)command.ExecuteScalar();
                Console.WriteLine(count);
            } 
        }
    }
}
