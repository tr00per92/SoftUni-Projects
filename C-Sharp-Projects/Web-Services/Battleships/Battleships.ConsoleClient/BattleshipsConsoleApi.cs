namespace Battleships.ConsoleClient
{
    using System.Net;
    using System.Text;
    using Newtonsoft.Json.Linq;
    using RestSharp;

    public class BattleshipsConsoleApi
    {
        private readonly RestClient restClient = new RestClient("http://localhost:62858/api/");
        private string accessToken;
        private string gameId;

        public string Register(string email, string pass, string confirmPass)
        {
            var request = new RestRequest("account/register", Method.POST);
            request.AddParameter("email", email);
            request.AddParameter("password", pass);
            request.AddParameter("confirmpassword", confirmPass);

            var response = this.restClient.Execute(request);
            if (response.StatusCode != HttpStatusCode.OK)
            {
                return "Registration error: " + response.Content;
            }

            return "Registration successfull.";
        }

        public string Login(string email, string pass)
        {
            var request = new RestRequest("account/login", Method.POST);
            request.AddParameter("username", email);
            request.AddParameter("password", pass);
            request.AddParameter("grant_type", "password");

            var response = this.restClient.Execute(request);
            if (response.StatusCode != HttpStatusCode.OK)
            {
                return "Login error: " + response.Content;
            }

            this.accessToken = JObject.Parse(response.Content)["access_token"].ToString();
            return "Login successfull.";
        }

        public string CreateGame()
        {
            if (this.accessToken == null)
            {
                return "You must be logged in.";
            }

            var request = new RestRequest("games/create", Method.POST);
            request.AddHeader("Authorization", "Bearer " + this.accessToken);

            var response = this.restClient.Execute(request);
            if (response.StatusCode != HttpStatusCode.OK)
            {
                return "Create game error: " + response.Content;
            }

            this.gameId = response.Content.Trim('"');
            return "Created game with ID: " + this.gameId;
        }

        public string JoinGame(string id)
        {
            if (this.accessToken == null)
            {
                return "You must be logged in.";
            }

            var request = new RestRequest("games/join", Method.POST);
            request.AddHeader("Authorization", "Bearer " + this.accessToken);
            request.AddParameter("gameid", id);

            var response = this.restClient.Execute(request);
            if (response.StatusCode != HttpStatusCode.OK)
            {
                return "Join game error: " + response.Content;
            }

            this.gameId = response.Content.Trim('"');
            return "Joined game with ID: " + this.gameId;
        }

        public string SetGame(string id)
        {
            if (this.accessToken == null)
            {
                return "You must be logged in.";
            }

            this.gameId = id;

            return "Continuing game with ID: " + id;
        }

        public string Play(int x, int y)
        {
            if (this.accessToken == null || this.gameId == null)
            {
                return "You must be logged and in a game.";
            }

            var request = new RestRequest("games/play", Method.POST);
            request.AddHeader("Authorization", "Bearer " + this.accessToken);
            request.AddParameter("gameid", this.gameId);
            request.AddParameter("positionx", x);
            request.AddParameter("positiony", y);

            var response = this.restClient.Execute(request);
            return response.Content.Trim('"');
        }

        public string GetField()
        {
            if (this.accessToken == null || this.gameId == null)
            {
                return "You must be logged and in a game.";
            }

            var request = new RestRequest("games/getfield/{id}", Method.GET);
            request.AddHeader("Authorization", "Bearer " + this.accessToken);
            request.AddUrlSegment("id", this.gameId);

            var response = this.restClient.Execute(request);
            if (response.StatusCode != HttpStatusCode.OK)
            {
                return "Get field error.";
            }

            var field = response.Content.Trim('"');
            var result = new StringBuilder();
            for (var i = 0; i < field.Length; i++)
            {
                if (i % 8 == 0)
                {
                    result.Append('\n');
                }

                result.Append(field[i]);
            }

            return result.ToString().Trim();
        }

        public string GetAvailableGames()
        {
            if (this.accessToken == null)
            {
                return "You must be logged in.";
            }

            var request = new RestRequest("games/available", Method.GET);
            request.AddHeader("Authorization", "Bearer " + this.accessToken);

            var response = this.restClient.Execute(request);
            return response.Content;
        }

        public string GetMyGames()
        {
            if (this.accessToken == null)
            {
                return "You must be logged in.";
            }

            var request = new RestRequest("games/mine", Method.GET);
            request.AddHeader("Authorization", "Bearer " + this.accessToken);

            var response = this.restClient.Execute(request);
            return response.Content;
        }
    }
}
