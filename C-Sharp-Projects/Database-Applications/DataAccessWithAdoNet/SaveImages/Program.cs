using System.Data.SqlClient;
using System.IO;

namespace SaveImages
{
    public class Program
    {
        public static void Main()
        {
            SqlConnection dbCon = new SqlConnection("Server=.; Database=Northwind; Integrated Security=true");
            dbCon.Open();
            using (dbCon)
            {
                SqlCommand command = new SqlCommand("SELECT CategoryName, Picture FROM Categories", dbCon);
                var reader = command.ExecuteReader();
                using (reader)
                {
                    while (reader.Read())
                    {
                        var picture = (byte[])reader["Picture"];
                        var name = ((string)reader["CategoryName"]).Replace("/", "-") + ".jpg";
                        File.WriteAllBytes("C:\\Temp\\" + name, picture);
                    }
                }
            } 
        }
    }
}
