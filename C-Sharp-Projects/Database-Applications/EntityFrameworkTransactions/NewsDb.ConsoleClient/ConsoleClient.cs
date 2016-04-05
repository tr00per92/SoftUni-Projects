namespace NewsDb.ConsoleClient
{
    using System;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using NewsDb.Data;

    public class ConsoleClient
    {
        public static void Main()
        {
            Console.WriteLine("Application started.");
            TryModifyNews();
        }

        private static void TryModifyNews()
        {
            using (var db = new NewsDbData())
            {
                var news = db.News.First();
                Console.WriteLine("Text from db: {0}", news.Content);
                Console.Write("Enter the corrected text: ");
                news.Content = Console.ReadLine();
                try
                {
                    db.SaveChanges();
                    Console.WriteLine("Changes successfully saved in the DB.");
                }
                catch (DbUpdateConcurrencyException)
                {
                    Console.Write("Conflict! ");
                    TryModifyNews();
                }
            }
        }
    }
}
