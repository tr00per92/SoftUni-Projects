namespace GenerateRandomMatches
{
    using System;
    using System.Linq;
    using System.Xml.Linq;
    using Football.Data.DbFirst;

    public class GenerateRandomMatches
    {
        private static readonly Random RandomGenerator = new Random();

        public static void Main()
        {
            var xml = XDocument.Load("../../../Helper.Files/generate-matches.xml");
            var generateNodes = xml.Descendants("generate");
            var counter = 1;
            foreach (var node in generateNodes)
            {
                Console.WriteLine("Processing request #{0} ...", counter++);

                var leagueName = GetLeagueName(node);
                var generateCount = GetGenerateCount(node);
                for (var i = 0; i < generateCount; i++)
                {
                    var randomGoals = GetRandomGoals(node);
                    var homeTeamGoals = RandomGenerator.Next(randomGoals + 1);
                    var awayTeamGoals = randomGoals - homeTeamGoals;
                    var homeTeam = GetRandomTeam(leagueName);
                    var awayTeam = GetRandomTeam(leagueName, homeTeam);
                    var matchDate = GetRandomDate(node);

                    Console.WriteLine("{0}: {1} - {2}: {3}-{4} ({5})", 
                        matchDate.ToString("dd-MMM-yyyy"), homeTeam, awayTeam, homeTeamGoals, awayTeamGoals, leagueName);

                    SaveMatchToDb(leagueName, homeTeam, awayTeam, homeTeamGoals, awayTeamGoals, matchDate);
                }

                Console.WriteLine();
            }
        }
        
        private static string GetRandomTeam(string leagueName, string opponentTeam = null)
        {
            using (var db = new FootballEntities())
            {
                League currentLeague = null;
                if (leagueName != "no league")
                {
                    currentLeague = db.Leagues.FirstOrDefault(l => l.LeagueName == leagueName);
                }

                string randomTeam;
                if (currentLeague != null)
                {
                    var randomNumber = RandomGenerator.Next(currentLeague.Teams.Count());
                    randomTeam = currentLeague.Teams.OrderBy(t => t.TeamName).Skip(randomNumber).First().TeamName;
                }
                else
                {
                    var randomNumber = RandomGenerator.Next(db.Teams.Count());
                    randomTeam = db.Teams.OrderBy(t => t.TeamName).Skip(randomNumber).First().TeamName;
                }

                if (randomTeam == opponentTeam)
                {
                    return GetRandomTeam(leagueName, opponentTeam);
                }

                return randomTeam;
            }
        }

        private static DateTime GetRandomDate(XContainer node)
        {
            var startDate = GetStartDate(node);
            var endDate = GetEndDate(node);
            var range = (endDate - startDate).Days;
            var randomDate = startDate.AddDays(RandomGenerator.Next(range));

            return randomDate;
        }

        private static DateTime GetEndDate(XContainer node)
        {
            var endDate = new DateTime(2015, 12, 31);
            if (node.Descendants("end-date").Any())
            {
                endDate = DateTime.Parse(node.Descendants("end-date").Single().Value);
            }

            return endDate;
        }

        private static DateTime GetStartDate(XContainer node)
        {
            var startDate = new DateTime(2000, 1, 1);
            if (node.Descendants("start-date").Any())
            {
                startDate = DateTime.Parse(node.Descendants("start-date").Single().Value);
            }

            return startDate;
        }

        private static int GetRandomGoals(XElement node)
        {
            var maxGoals = 5;
            if (node.Attribute("max-goals") != null)
            {
                maxGoals = int.Parse(node.Attribute("max-goals").Value);
            }

            var randomGoals = RandomGenerator.Next(maxGoals + 1);

            return randomGoals;
        }

        private static string GetLeagueName(XContainer node)
        {
            var leagueName = "no league";
            if (node.Descendants("league").Any())
            {
                leagueName = node.Descendants("league").Single().Value;
            }

            return leagueName;
        }

        private static int GetGenerateCount(XElement node)
        {
            var generateCount = 10;
            if (node.Attribute("generate-count") != null)
            {
                generateCount = int.Parse(node.Attribute("generate-count").Value);
            }

            return generateCount;
        }

        private static void SaveMatchToDb(string leagueName, string homeTeam, string awayTeam, int homeTeamGoals, int awayTeamGoals, DateTime matchDate)
        {
            using (var db = new FootballEntities())
            {
                db.TeamMatches.Add(new TeamMatch
                {
                    League = db.Leagues.FirstOrDefault(l => l.LeagueName == leagueName),
                    HomeTeam = db.Teams.FirstOrDefault(t => t.TeamName == homeTeam),
                    AwayTeam = db.Teams.FirstOrDefault(t => t.TeamName == awayTeam),
                    HomeGoals = homeTeamGoals,
                    AwayGoals = awayTeamGoals,
                    MatchDate = matchDate
                });

                db.SaveChanges();
            }
        }
    }
}
