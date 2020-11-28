using MatchStats.Models;
using System.Collections.Generic;

namespace MatchStats.Services.Interfaces
{
    public interface IAllTeamsService
    {
        List<string> GetAllTeams(League league);
    }
}
