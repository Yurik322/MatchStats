using System;

namespace MatchStats.Models
{
    public class Match
    {
        public string Round { get; set; }
        public DateTime Date { get; set; }
        public string Team1 { get; set; }
        public string Team2 { get; set; }
        public Score Score { get; set; }
    }
}
