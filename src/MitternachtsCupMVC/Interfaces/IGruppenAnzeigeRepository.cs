using MitternachtsCupMVC.Models;

namespace MitternachtsCupMVC.Interfaces;

public interface IGruppenAnzeigeRepository
{
    Task<IEnumerable<Team>> GetGruppeATeams();
    Task<IEnumerable<Spiel>> GetGruppeASpiele();
    Task<IEnumerable<Team>> GetGruppeBTeams();
    Task<IEnumerable<Spiel>> GetGruppeBSpiele();
    Task<IEnumerable<Team>> GetGruppeCTeams();
    Task<IEnumerable<Spiel>> GetGruppeCSpiele();
    Task<IEnumerable<Team>> GetGruppeDTeams();
    Task<IEnumerable<Spiel>> GetGruppeDSpiele();
    Task<IEnumerable<Team>> GetGruppeETeams();
    Task<IEnumerable<Spiel>> GetGruppeESpiele();
    Task<IEnumerable<Team>> GetGruppeFTeams();
    Task<IEnumerable<Spiel>> GetGruppeFSpiele();
    Task<IEnumerable<Team>> GetGruppeGTeams();
    Task<IEnumerable<Spiel>> GetGruppeGSpiele();
    
}