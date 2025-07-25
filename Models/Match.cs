﻿using System;
using System.Collections.Generic;

namespace FootballLeagueConsoleApp.Models;

public partial class Match
{
    public int MatchId { get; set; }

    public int? HomeTeamId { get; set; }

    public int? AwayTeamId { get; set; }

    public DateOnly MatchDate { get; set; }

    public int? HomeScore { get; set; }

    public int? AwayScore { get; set; }

    public virtual Team? AwayTeam { get; set; }

    public virtual Team? HomeTeam { get; set; }
}
