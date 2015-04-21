namespace ExportLeaguesAndTeamsAsJson
{
    using System.IO;
    using System.Linq;
    using Football.Data.DbFirst;
    using Newtonsoft.Json;

    public class ExportLeaguesAndTeamsAsJson
    {
        public static void Main()
        {
            using (var db = new FootballEntities())
            {
                var leaguesAndTeams = db.Leagues
                    .OrderBy(l => l.LeagueName)
                    .Select(l => new
                    {
                        leagueName = l.LeagueName,
                        teams = l.Teams.OrderBy(t => t.TeamName).Select(t => t.TeamName)
                    })
                    .ToList();

                var json = JsonConvert.SerializeObject(leaguesAndTeams, Formatting.Indented);
                File.WriteAllText("../../../Helper.Files/leagues-and-teams.json", json);
            }
        }
    }
}
