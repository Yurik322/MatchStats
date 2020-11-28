using MatchStats.Models;
using MatchStats.Services.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace MatchStats.Services.Implementations
{
    public class CurrentLeague : ILeagueService
    {
        public League GetLeague(string path)
        {
            var json = System.IO.File.ReadAllText(path);
            var league = JsonConvert.DeserializeObject<League>(json);
            return league;
        }

        public List<League> GetAllLeagues()
        {
            var leagues = new List<League>();

            var league = GetLeague("en.1.json");
            leagues.Add(league);
            league = GetLeague("en.2.json");
            leagues.Add(league);
            league = GetLeague("en.3.json");
            leagues.Add(league);

            return leagues;
        }
    }
}
