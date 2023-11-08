using MitternachtsCupMVC.Models;

namespace MitternachtsCupMVC.Interfaces;

public interface ITeamRepository
{
    Task<IEnumerable<Team>> GetAll();
    Task<Team> GetByIdAsync(int id);
    bool Add(Team team);
    bool Update(Team team);
    bool Delete(Team team);
    bool Save();
}