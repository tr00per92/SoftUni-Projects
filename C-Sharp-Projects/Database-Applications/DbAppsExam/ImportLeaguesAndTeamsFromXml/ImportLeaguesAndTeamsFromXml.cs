namespace ImportLeaguesAndTeamsFromXml
{
    using System;
    using System.Linq;
    using System.Xml.Linq;
    using Football.Data.DbFirst;

    public class ImportLeaguesAndTeamsFromXml
    {
        public static void Main()
        {
            using (var db = new FootballEntities())
            {
                var xml = XDocument.Load("../../../Helper.Files/leagues-and-teams.xml");
                var counter = 1;
                foreach (var league in xml.Descendants("league"))
                {
                    Console.WriteLine("Processing league #{0} ...", counter++);
                    var currentLeague = GetOrCreateLeague(league, db);
                    foreach (var team in league.Descendants("team"))
                    {
                        if (team.Attribute("name") == null)
                        {
                            Console.WriteLine("Missing team name attribute.");
                            continue;
                        }

                        var currentTeam = GetOrCreateTeam(team, db);
                        AddTeamToLeague(currentTeam, currentLeague);
                    }

                    db.SaveChanges();
                    Console.WriteLine();
                }
            }
        }

        private static void AddTeamToLeague(Team team, League league)
        {
            if (league != null)
            {
                if (team.Leagues.Contains(league))
                {
                    Console.WriteLine("Existing team in league: {0} belongs to {1}", team.TeamName, league.LeagueName);
                }
                else
                {
                    team.Leagues.Add(league);
                    Console.WriteLine("Added team to league: {0} to league {1}", team.TeamName, league.LeagueName);
                }
            }
        }

        private static Team GetOrCreateTeam(XElement team, FootballEntities db)
        {
            var teamName = team.Attribute("name").Value;
            string countryName = null;
            if (team.Attribute("country") != null)
            {
                countryName = team.Attribute("country").Value;
            }

            Team currentTeam;
            if (countryName != null)
            {
                currentTeam = db.Teams.FirstOrDefault(t => t.TeamName == teamName && t.Country.CountryName == countryName);
            }
            else
            {
                currentTeam = db.Teams.FirstOrDefault(t => t.TeamName == teamName);
            }

            if (currentTeam == null)
            {
                if (countryName != null)
                {
                    var country = db.Countries.FirstOrDefault(c => c.CountryName == countryName);
                    currentTeam = new Team { TeamName = teamName, Country = country };
                }
                else
                {
                    currentTeam = new Team { TeamName = teamName };
                }

                db.Teams.Add(currentTeam);
                Console.WriteLine("Created team: {0} ({1})",
                    currentTeam.TeamName,
                    currentTeam.Country != null ? currentTeam.Country.CountryName : "no country");
            }
            else
            {
                Console.WriteLine("Existing team: {0} ({1})",
                    currentTeam.TeamName,
                    currentTeam.Country != null ? currentTeam.Country.CountryName : "no country");
            }

            return currentTeam;
        }

        private static League GetOrCreateLeague(XContainer league, FootballEntities db)
        {
            League currentLeague = null;
            var leagueNameNode = league.Descendants("league-name").SingleOrDefault();
            if (leagueNameNode != null)
            {
                currentLeague = db.Leagues.FirstOrDefault(l => l.LeagueName == leagueNameNode.Value);
                if (currentLeague == null)
                {
                    currentLeague = new League { LeagueName = leagueNameNode.Value };
                    db.Leagues.Add(currentLeague);
                    Console.WriteLine("Created league: {0}", currentLeague.LeagueName);
                }
                else
                {
                    Console.WriteLine("Existing league: {0}", currentLeague.LeagueName);
                }
            }

            return currentLeague;
        }
    }
}
