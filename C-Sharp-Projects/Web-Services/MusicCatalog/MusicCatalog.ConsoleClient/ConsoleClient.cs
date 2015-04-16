namespace MusicCatalog.ConsoleClient
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;

    public class ConsoleClient
    {
        public static void Main()
        {
            Task.Run(async () =>
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:37079/api/");
                    await ArtistsControllerTest(client);
                    await SongsControllerTest(client);
                    await AlbumsControllerTest(client);
                }
            }).Wait();
        }

        private static async Task AlbumsControllerTest(HttpClient client)
        {
            // create album
            await client.PostAsync("Albums/Create",
                new FormUrlEncodedContent(new[] { new KeyValuePair<string, string>("title", "album 009") }));
            await client.PostAsync("Albums/Create",
                new FormUrlEncodedContent(new[] { new KeyValuePair<string, string>("title", "album 010") }));

            // get all albums
            Console.WriteLine(await client.GetStringAsync("Albums/All"));

            // update album
            await client.PutAsync("Albums/Update",
                new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("id", "2"),
                    new KeyValuePair<string, string>("year", "2014"),
                    new KeyValuePair<string, string>("producer", "gosho ot pochivka")
                }));

            // delete album 
            await client.DeleteAsync("Albums/Delete/1");

            // add song to album
            await client.PutAsync("Albums/AddSong?albumId=2&songId=2", null);

            // add artist to album
            await client.PutAsync("Albums/AddArtist?albumId=2&artistId=2", null);
        }

        private static async Task SongsControllerTest(HttpClient client)
        {
            // create songs
            await client.PostAsync("Songs/Create",
                new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("title", "qka pesen 007"),
                    new KeyValuePair<string, string>("artistid", "2") 
                }));
            await client.PostAsync("Songs/Create",
                new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("title", "qka pesen 008"),
                    new KeyValuePair<string, string>("artistid", "2") 
                }));

            // get all songs
            Console.WriteLine(await client.GetStringAsync("Songs/All"));

            // update song
            await client.PutAsync("Songs/Update",
                new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("id", "2"),
                    new KeyValuePair<string, string>("year", "2010"),
                    new KeyValuePair<string, string>("genre", "narodna pesen")
                }));

            // delete song 
            await client.DeleteAsync("api/Songs/Delete/1");
        }

        private static async Task ArtistsControllerTest(HttpClient client)
        {
            // create artists
            await client.PostAsync("Artists/Create",
                new FormUrlEncodedContent(new[] { new KeyValuePair<string, string>("name", "pesho muzikanta") }));
            await client.PostAsync("Artists/Create",
                new FormUrlEncodedContent(new[] { new KeyValuePair<string, string>("name", "gosho trompeta") }));

            // get all artists
            Console.WriteLine(await client.GetStringAsync("Artists/All"));

            // update artist
            await client.PutAsync("Artists/Update",
                new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("id", "2"),
                    new KeyValuePair<string, string>("country", "Bulgaria"),
                    new KeyValuePair<string, string>("birthday", DateTime.Now.ToString())
                }));

            // delete artist 
            await client.DeleteAsync("Artists/Delete/1");
        }
    }
}
