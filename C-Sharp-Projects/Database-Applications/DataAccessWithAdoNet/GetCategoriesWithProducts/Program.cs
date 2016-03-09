using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace GetCategoriesWithProducts
{
    public class Program
    {
        public static void Main()
        {
            SqlConnection dbCon = new SqlConnection("Server=.; Database=Northwind; Integrated Security=true");
            dbCon.Open();
            using (dbCon)
            {
                SqlCommand command = new SqlCommand("SELECT c.CategoryName, p.ProductName FROM Categories c JOIN Products p ON p.CategoryID = c.CategoryID", dbCon);
                var categoriesProducts = new Dictionary<string, List<string>>();
                var reader = command.ExecuteReader();
                using (reader)
                {
                    while (reader.Read())
                    {
                        var category = (string)reader["CategoryName"];
                        if (!categoriesProducts.ContainsKey(category))
                        {
                            categoriesProducts.Add(category, new List<string>());
                        }

                        categoriesProducts[category].Add((string)reader["ProductName"]);
                    }
                }

                foreach (var pair in categoriesProducts)
                {
                    Console.WriteLine("{0} -> {1}", pair.Key, string.Join(", ", pair.Value));
                    Console.WriteLine();
                }
            } 
        }
    }
}
