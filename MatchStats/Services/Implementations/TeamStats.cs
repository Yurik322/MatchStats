using MatchStats.Models;
using MatchStats.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MatchStats.Services.Implementations
{
    public class TeamStats : ITeamStatsService
    {
        private readonly IAllTeamsService _team;

        public TeamStats(IAllTeamsService team)
        {
            _team = team;
        }

        /// <summary>
        /// Get all the statistics on the team - scored, missed, difference goals.
        /// </summary>
        /// <param name="league">Input data about the league.</param>
        /// <returns>List of team goals.</returns>
        public List<TeamGoals> GetTeamsStats(League league)
        {
            var teamsGoals = new List<TeamGoals>();

            var scoredGoals = GetTeamsGoals(league, true);
            var missedGoals = GetTeamsGoals(league, false);
            var differenceGoals = GetTeamGoalsDifference(league);

            var team = new TeamGoals();

            foreach (var t in scoredGoals)
            {
                missedGoals.TryGetValue(t.Key, out var missed);
                scoredGoals.TryGetValue(t.Key, out var scored);
                differenceGoals.TryGetValue(t.Key, out var difference);

                team.Name = t.Key;
                team.ScoredGoals = scored;
                team.MissedGoals = missed;
                team.DifferenceGoals = difference;

                teamsGoals.Add(team);

                team = new TeamGoals();
            }

            return teamsGoals;
        }

        /// <summary>
        /// Will count goals scored / missed.
        /// </summary>
        /// <param name="league">Input data about the league.</param>
        /// <param name="scored">When scored == true - scored goals, scored == false - missed goals.</param>
        /// <returns>Dictionary of team and goals.</returns>
        public Dictionary<string, int> GetTeamsGoals(League league, bool scored)
        {
            var result = new Dictionary<string, int>();

            var teams = _team.GetAllTeams(league);

            foreach (var team in teams)
            {
                var goals = countTeamGoals(league, team, scored);
                result.Add(team, goals);
            }

            return result;
        }

        /// <summary>
        /// Get the difference between scored and missed.
        /// </summary>
        /// <param name="league">Input data about the league.</param>
        /// <returns>Dictionary of team and difference goals.</returns>
        public Dictionary<string, int> GetTeamGoalsDifference(League league)
        {
            var result = new Dictionary<string, int>();

            var scoredGoals = GetTeamsGoals(league, true);
            var missedGoals = GetTeamsGoals(league, false);

            foreach (var team in scoredGoals)
            {
                missedGoals.TryGetValue(team.Key, out var goals);
                var totalGoals = team.Value - goals;

                result.Add(team.Key, totalGoals);
            }

            return result;
        }

        /// <summary>
        /// Counting goals scored / missed.
        /// </summary>
        /// <param name="league">Input data about the league.</param>
        /// <param name="team">Input data about the team.</param>
        /// <param name="scored">When scored == true - scored goals, scored == false - missed goals.</param>
        /// <returns>Amount of goals.</returns>
        private static int countTeamGoals(League league, string team, bool scored)
        {
            var temp = Convert.ToInt32(!scored);
            // Skip null when score fields in json are empty.
            var result = league.Matches.Where(x => x.Team1 == team)
                                           .Where(x => x.Score != null)
                                           .Sum(x => x.Score.FT[temp]);

            temp = Convert.ToInt32(scored);
            result += league.Matches.Where(x => x.Team2 == team)
                                    .Where(x => x.Score != null)
                                    .Sum(x => x.Score.FT[temp]);

            return result;
        }
    }
}
