namespace ListTeamNames
{
    using System;
    using Football.Data.DbFirst;

    public class ListTeamNames
    {
        public static void Main()
        {
            using (var db = new FootballEntities())
            {
                foreach (var team in db.Teams)
                {
                    Console.WriteLine(team.TeamName);
                }
            }
        }
    }
}
