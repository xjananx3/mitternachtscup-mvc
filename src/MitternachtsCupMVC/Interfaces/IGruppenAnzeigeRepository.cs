using MitternachtsCupMVC.Data;
using MitternachtsCupMVC.Models;

namespace MitternachtsCupMVC.Interfaces;

public interface IGruppenAnzeigeRepository
{
    Task<IEnumerable<TeamInGruppe>> GetGruppeATeams();
    Task<IEnumerable<GruppenSpielTurnierPlan>> GetGruppeASpiele();
    Task<IEnumerable<TeamInGruppe>> GetGruppeBTeams();
    Task<IEnumerable<GruppenSpielTurnierPlan>> GetGruppeBSpiele();
    Task<IEnumerable<TeamInGruppe>> GetGruppeCTeams();
    Task<IEnumerable<GruppenSpielTurnierPlan>> GetGruppeCSpiele();
    Task<IEnumerable<TeamInGruppe>> GetGruppeDTeams();
    Task<IEnumerable<GruppenSpielTurnierPlan>> GetGruppeDSpiele();
    Task<IEnumerable<TeamInGruppe>> GetGruppeETeams();
    Task<IEnumerable<GruppenSpielTurnierPlan>> GetGruppeESpiele();
    Task<IEnumerable<TeamInGruppe>> GetGruppeFTeams();
    Task<IEnumerable<GruppenSpielTurnierPlan>> GetGruppeFSpiele();
    Task<IEnumerable<TeamInGruppe>> GetGruppeGTeams();
    Task<IEnumerable<GruppenSpielTurnierPlan>> GetGruppeGSpiele();
    
}