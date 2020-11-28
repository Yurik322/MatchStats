using MatchStats.Models;
using MatchStats.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace MatchStats.Services.Implementations
{
    public class AllTeams : IAllTeamsService
    {
        public List<string> GetAllTeams(League league)
        {
            return league.Matches.Select(x => x.Team1).Distinct().ToList();
        }
    }
}
