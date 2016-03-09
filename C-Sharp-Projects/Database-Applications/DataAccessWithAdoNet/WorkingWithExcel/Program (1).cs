using System;
using System.Data;
using System.Data.OleDb;

namespace WorkingWithExcel
{
    public class Program
    {
        public static void Main()
        {
            AddRow("Gecata", 20);
            AddRow("Toshko", Math.PI);
            ReadData();
        }

        private static void AddRow(string name, double score)
        {
            var connection = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\\Temp\\sample.xls;Extended Properties='Excel 8.0;HDR=Yes'");
            connection.Open();
            using (connection)
            {
                using (var command = new OleDbCommand("INSERT INTO [Scores$] VALUES (@name, @score)", connection))
                {
                    command.Parameters.AddWithValue("@name", name);
                    command.Parameters.AddWithValue("@score", score);
                    command.ExecuteNonQuery();
                }
            }
        }

        private static void ReadData()
        {
            var connection = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\\Temp\\sample.xls;Extended Properties='Excel 8.0;HDR=Yes'");
            connection.Open();
            using (connection)
            {
                using (var command = new OleDbCommand("SELECT * FROM [Scores$]", connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine("{0} -> {1}", reader["Name"], reader["Score"]);
                        }
                    }
                }
            }
        }
    }
}
