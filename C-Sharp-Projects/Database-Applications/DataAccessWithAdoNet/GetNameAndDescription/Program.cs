using System;
using System.Data.SqlClient;

namespace GetNameAndDescription
{
    public class Program
    {
        public static void Main()
        {
            SqlConnection dbCon = new SqlConnection("Server=.; Database=Northwind; Integrated Security=true");
            dbCon.Open();
            using (dbCon)
            {
                SqlCommand command = new SqlCommand("SELECT CategoryName, Description FROM Categories", dbCon);
                var reader = command.ExecuteReader();
                using (reader)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine("Name: {0} -> Description: {1}", reader["CategoryName"], reader["Description"]);
                    }
                }
            } 
        }
    }
}
