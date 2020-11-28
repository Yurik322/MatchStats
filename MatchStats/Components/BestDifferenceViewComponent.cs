using MatchStats.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MatchStats.Components
{
    public class BestDifferenceViewComponent : ViewComponent
    {
        private readonly IDifferenceService _difference;
        private readonly ILeagueService _league;

        public BestDifferenceViewComponent(IDifferenceService difference, ILeagueService league)
        {
            _difference = difference;
            _league = league;
        }

        // The best difference
        public string Invoke(string path)
        {
            var team = _difference.BestDifference(_league.GetLeague(path));

            return $"The best team with difference is " + team.Name + ". Difference is " + team.DifferenceGoals;
        }
    }
}
