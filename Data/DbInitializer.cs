using FootballLeagueConsoleApp.Models;
using System.Linq;

public static class DbInitializer
{
    public static void Initialize(FootballLeagueContext context)
    {
        // Ensure DB is created
        context.Database.EnsureCreated();

        // Look for any teams already in the DB.
        if (context.Teams.Any())
        {
            return;   // DB has been seeded
        }

        var teams = new Team[]
        {
            new Team { Name = "Lahore Lions", City = "Lahore" },
            new Team { Name = "Karachi Kings", City = "Karachi" },
            new Team { Name = "Islamabad Eagles", City = "Islamabad" }
        };

        context.Teams.AddRange(teams);
        context.SaveChanges();

        var players = new Player[]
        {
            new Player { Name = "Ali Khan", Position = "Forward", TeamId = teams[0].TeamId },
            new Player { Name = "Sara Malik", Position = "Goalkeeper", TeamId = teams[1].TeamId },
            new Player { Name = "Ahmed Raza", Position = "Defender", TeamId = teams[2].TeamId }
        };

        context.Players.AddRange(players);
        context.SaveChanges();

        // Add Matches or other entities similarly if you want
    }
}
