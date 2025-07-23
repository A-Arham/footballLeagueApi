using System;
using System.Collections.Generic;

namespace FootballLeagueConsoleApp.Models;

public partial class Player
{
    public int PlayerId { get; set; }

    public string Name { get; set; } = null!;

    public int Age { get; set; }

    public string? Position { get; set; }

    public int? TeamId { get; set; }

    public virtual Team? Team { get; set; }
}
