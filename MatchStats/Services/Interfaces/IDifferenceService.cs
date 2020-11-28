using MatchStats.Models;

namespace MatchStats.Services.Interfaces
{
    public interface IDifferenceService
    {
        public TeamGoals BestDifference(League league);
    }
}
