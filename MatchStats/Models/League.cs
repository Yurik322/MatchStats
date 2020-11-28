using System.Collections.Generic;

namespace MatchStats.Models
{
    public class League
    {
        public string Name { get; set; }
        public List<Match> Matches { get; set; }
    }
}
