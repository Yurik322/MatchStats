using MatchStats.Models;
using MatchStats.Services.Interfaces;
using System.Linq;

namespace MatchStats.Services.Implementations
{
    public class Difference : IDifferenceService
    {
        private readonly ITeamStatsService _stats;

        public Difference(ITeamStatsService stats)
        {
            _stats = stats;
        }

        /// <summary>
        /// Get the best difference between scored and missed goals in team.
        /// </summary>
        /// <param name="league">Input data about the league.</param>
        /// <returns>Best difference team.</returns>
        public TeamGoals BestDifference(League league)
        {
            var teams = _stats.GetTeamsStats(league);
            var dif = teams.Max(x => x.DifferenceGoals);

            var result = teams.Where(a => a.DifferenceGoals == dif);

            // When more than one team.
            if (result.Count() > 1)
            {
                var max = result.Max(x => x.ScoredGoals);

                return result.FirstOrDefault(x => x.ScoredGoals == max);
            }

            return result.FirstOrDefault();
        }
    }
}
