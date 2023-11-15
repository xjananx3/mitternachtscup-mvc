using MitternachtsCupMVC.Data;
using MitternachtsCupMVC.Models;

namespace MitternachtsCupMVC.Interfaces;

public interface IGruppenAnzeigeRepository
{
    Task<IEnumerable<TeamInGruppe>> GetGruppeATeams();
    Task<IEnumerable<GruppenSpielTurnierPlan>> GetKommendeGruppeASpiele();
    Task<IEnumerable<GruppenSpielTurnierPlan>> GetVergangeneGruppeASpiele();
    Task<IEnumerable<TeamInGruppe>> GetGruppeBTeams();
    Task<IEnumerable<GruppenSpielTurnierPlan>> GetKommendeGruppeBSpiele();
    Task<IEnumerable<GruppenSpielTurnierPlan>> GetVergangeneGruppeBSpiele();
    Task<IEnumerable<TeamInGruppe>> GetGruppeCTeams();
    Task<IEnumerable<GruppenSpielTurnierPlan>> GetKommendeGruppeCSpiele();
    Task<IEnumerable<GruppenSpielTurnierPlan>> GetVergangeneGruppeCSpiele();
    Task<IEnumerable<TeamInGruppe>> GetGruppeDTeams();
    Task<IEnumerable<GruppenSpielTurnierPlan>> GetKommendeGruppeDSpiele();
    Task<IEnumerable<GruppenSpielTurnierPlan>> GetVergangeneGruppeDSpiele();
    Task<IEnumerable<TeamInGruppe>> GetGruppeETeams();
    Task<IEnumerable<GruppenSpielTurnierPlan>> GetKommendeGruppeESpiele();
    Task<IEnumerable<GruppenSpielTurnierPlan>> GetVergangeneGruppeESpiele();
    Task<IEnumerable<TeamInGruppe>> GetGruppeFTeams();
    Task<IEnumerable<GruppenSpielTurnierPlan>> GetKommendeGruppeFSpiele();
    Task<IEnumerable<GruppenSpielTurnierPlan>> GetVergangeneGruppeFSpiele();
    Task<IEnumerable<TeamInGruppe>> GetGruppeGTeams();
    Task<IEnumerable<GruppenSpielTurnierPlan>> GetKommendeGruppeGSpiele();
    Task<IEnumerable<GruppenSpielTurnierPlan>> GetVergangeneGruppeGSpiele();
    
}