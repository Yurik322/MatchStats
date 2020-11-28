using MatchStats.Models;

namespace MatchStats.Services.Interfaces
{
    public interface IAttackService
    {
        TeamGoals BestAttack(League league);
    }
}
