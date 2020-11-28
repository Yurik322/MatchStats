using MatchStats.Models;

namespace MatchStats.Services.Interfaces
{
    public interface IDayScoreService
    {
        DayGoals GetTheMostScoringDay();
    }
}
