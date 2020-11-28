using MatchStats.Models;
using MatchStats.Services.Interfaces;
using System.Linq;

namespace MatchStats.Services.Implementations
{
    public class Attack : IAttackService
    {
        private readonly ITeamStatsService _stats;

        public Attack(ITeamStatsService stats)
        {
            _stats = stats;
        }

        public TeamGoals BestAttack(League league)
        {
            var teams = _stats.GetTeamsStats(league);
            var max = teams.Max(x => x.ScoredGoals);

            return teams.FirstOrDefault(a => a.ScoredGoals == max);
        }
    }
}
