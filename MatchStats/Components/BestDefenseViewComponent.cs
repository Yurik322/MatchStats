using MatchStats.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MatchStats.Components
{
    public class BestDefenseViewComponent : ViewComponent
    {
        private readonly IDefenseService _defense;
        private readonly ILeagueService _league;

        public BestDefenseViewComponent(IDefenseService defense, ILeagueService league)
        {
            _defense = defense;
            _league = league;
        }

        // The best defensive team
        public string Invoke(string path)
        {
            var team = _defense.BestDefense(_league.GetLeague(path));

            return $"The best defensive team is " + team.Name + ". It missed " + team.MissedGoals + " times";
        }
    }
}
