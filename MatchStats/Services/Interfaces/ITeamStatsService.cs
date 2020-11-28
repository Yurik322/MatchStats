using MatchStats.Models;
using System.Collections.Generic;

namespace MatchStats.Services.Interfaces
{
    public interface ITeamStatsService
    {
        List<TeamGoals> GetTeamsStats(League league);
    }
}
