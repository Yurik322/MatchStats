using MatchStats.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MatchStats.Components
{
    public class MostScoringDayViewComponent : ViewComponent
    {
        private readonly IDayScoreService _score;

        public MostScoringDayViewComponent(IDayScoreService score)
        {
            _score = score;
        }

        // The most scoring day in all leagues
        public string Invoke()
        {
            var day = _score.GetTheMostScoringDay();

            return $"The most scoring day is " + day.Name.ToShortDateString() + " with " + day.Score + " goals";
        }
    }
}
