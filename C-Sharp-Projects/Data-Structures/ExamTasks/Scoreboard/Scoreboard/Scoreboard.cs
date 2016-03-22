namespace Scoreboard
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Wintellect.PowerCollections;

    public class Scoreboard
    {
        private readonly SortedSet<string> gameNames = new SortedSet<string>(); 
        private readonly IDictionary<string, string> users = new Dictionary<string, string>();
        private readonly IDictionary<string, string> games = new Dictionary<string, string>();
        private readonly IDictionary<string, OrderedBag<Score>> scores = new Dictionary<string, OrderedBag<Score>>();

        public string RegisterUser(string username, string password)
        {
            if (this.users.ContainsKey(username))
            {
                return "Duplicated user";
            }

            this.users[username] = password;
            return "User registered";
        }

        public string RegisterGame(string gamename, string password)
        {
            if (this.games.ContainsKey(gamename))
            {
                return "Duplicated game";
            }

            this.games[gamename] = password;
            this.gameNames.Add(gamename);
            return "Game registered";
        }

        public string AddScore(string username, string userPass, string gamename, string gamePass, int score)
        {
            if (!this.users.ContainsKey(username) ||
                this.users[username] != userPass ||
                !this.games.ContainsKey(gamename) ||
                this.games[gamename] != gamePass)
            {
                return "Cannot add score";
            }

            if (!this.scores.ContainsKey(gamename))
            {
                this.scores[gamename] = new OrderedBag<Score>();
            }

            this.scores[gamename].Add(new Score { Name = username, Points = score });

            return "Score added";
        }

        public string ShowScoreboard(string gamename)
        {
            if (!this.games.ContainsKey(gamename))
            {
                return "Game not found";
            }

            if (!this.scores.ContainsKey(gamename))
            {
                return "No score";
            }
            
            var scoreList = this.scores[gamename].AsList();
            var result = new List<string>();
            for (var i = 0; i < 10; i++)
            {
                var item = scoreList[scoreList.Count - 1 - i];
                result.Add(string.Format("#{0} {1}", i + 1, item));

                if (i + 1 >= scoreList.Count)
                {
                    break;
                }
            }

            return string.Join(Environment.NewLine, result);
        }

        public string DeleteGame(string gamename, string password)
        {
            if (!this.games.ContainsKey(gamename) || this.games[gamename] != password)
            {
                return "Cannot delete game";
            }

            this.games.Remove(gamename);
            this.scores.Remove(gamename);
            this.gameNames.Remove(gamename);

            return "Game deleted";
        }

        public string ListByPrefix(string prefix)
        {
            var results = this.gameNames.Where(x => StartsWith(x, prefix)).Take(10).ToList();
            if (results.Any())
            {
                return string.Join(", ", results);
            }

            return "No matches";
        }

        private static bool StartsWith(string str, string prefix)
        {
            if (prefix.Length > str.Length)
            {
                return false;
            }

            for (var i = 0; i < prefix.Length; i++)
            {
                if (prefix[i] != str[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
