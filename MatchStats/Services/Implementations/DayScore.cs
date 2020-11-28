using MatchStats.Models;
using MatchStats.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MatchStats.Services.Implementations
{
    public class DayScore : IDayScoreService
    {
        private readonly ILeagueService _league;

        public DayScore(ILeagueService league)
        {
            _league = league;
        }

        public DayGoals GetTheMostScoringDay()
        {
            var max = getDayScores().Max(x => x.Score);

            return getDayScores().FirstOrDefault(x => x.Score == max);
        }

        private IEnumerable<DayGoals> getDayScores()
        {
            var dayScores = new List<DayGoals>();
            var day = new DayGoals();

            var leagues = _league.GetAllLeagues();
            var days = getAllDates();

            // Take the day with the largest amount of goals in all leagues.
            foreach (var d in days)
            {
                day.Name = d.Date;

                day.Score = leagues.Sum(x => x.Matches.Where(y => y.Date == d)
                                                            .Where(y => y.Score != null)
                                                            .Sum(z => z.Score.FT[0] + z.Score.FT[1]));
                dayScores.Add(day);
                day = new DayGoals();
            }

            return dayScores;
        }

        private IEnumerable<DateTime> getAllDates()
        {
            var league1 = _league.GetLeague("en.1.json");
            var league2 = _league.GetLeague("en.2.json");
            var league3 = _league.GetLeague("en.3.json");

            var days1 = league1.Matches.Select(x => x.Date).Distinct().ToList();
            var days2 = league2.Matches.Select(x => x.Date).Distinct().ToList();
            var days3 = league3.Matches.Select(x => x.Date).Distinct().ToList();

            return days1.Union(days2.Union(days3)).Distinct().ToList();
        }
    }
}
