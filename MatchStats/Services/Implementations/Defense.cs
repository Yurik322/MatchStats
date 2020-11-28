using MatchStats.Models;
using MatchStats.Services.Interfaces;
using System.Linq;

namespace MatchStats.Services.Implementations
{
    public class Defense : IDefenseService
    {
        private readonly ITeamStatsService _stats;

        public Defense(ITeamStatsService stats)
        {
            _stats = stats;
        }

        public TeamGoals BestDefense(League league)
        {
            var teams = _stats.GetTeamsStats(league);
            var min = teams.Min(x => x.MissedGoals);

            return teams.FirstOrDefault(a => a.MissedGoals == min);
        }
    }
}
