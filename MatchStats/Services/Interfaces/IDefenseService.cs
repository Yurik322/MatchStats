using MatchStats.Models;

namespace MatchStats.Services.Interfaces
{
    public interface IDefenseService
    {
        TeamGoals BestDefense(League league);
    }
}
