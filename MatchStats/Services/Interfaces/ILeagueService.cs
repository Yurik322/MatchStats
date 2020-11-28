using MatchStats.Models;
using System.Collections.Generic;

namespace MatchStats.Services.Interfaces
{
    public interface ILeagueService
    {
        League GetLeague(string path);

        public List<League> GetAllLeagues();
    }
}
