using MatchStats.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MatchStats.Components
{
    public class BestAttackViewComponent : ViewComponent
    {
        private readonly IAttackService _attack;
        private readonly ILeagueService _league;

        public BestAttackViewComponent(IAttackService attack, ILeagueService league)
        {
            _attack = attack;
            _league = league;
        }

        // The most scoring team
        public string Invoke(string path)
        {
            var team = _attack.BestAttack(_league.GetLeague(path));

            return $"The most scoring team is " + team.Name + ". It scored " + team.ScoredGoals + " times";
        }
    }
}
