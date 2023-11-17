using MitternachtsCupMVC.Data;
using MitternachtsCupMVC.Models;

namespace MitternachtsCupMVC;

public class GruppenPhaseViewModel
{
    public IEnumerable<TeamInGruppe> GruppeATeams { get; set; }
    public IEnumerable<GruppenSpielTurnierPlan> VergangeneGruppeASpiele { get; set; }
    public IEnumerable<GruppenSpielTurnierPlan> KommendeGruppeASpiele { get; set; }
    
    public IEnumerable<TeamInGruppe> GruppeBTeams { get; set; }
    public IEnumerable<GruppenSpielTurnierPlan> VergangeneGruppeBSpiele { get; set; }
    public IEnumerable<GruppenSpielTurnierPlan> KommendeGruppeBSpiele { get; set; }
    
    public IEnumerable<TeamInGruppe> GruppeCTeams { get; set; }
    public IEnumerable<GruppenSpielTurnierPlan> VergangeneGruppeCSpiele { get; set; }
    public IEnumerable<GruppenSpielTurnierPlan> KommendeGruppeCSpiele { get; set; }
    
    public IEnumerable<TeamInGruppe> GruppeDTeams { get; set; }
    public IEnumerable<GruppenSpielTurnierPlan> VergangeneGruppeDSpiele { get; set; }
    public IEnumerable<GruppenSpielTurnierPlan> KommendeGruppeDSpiele { get; set; }
    
    public IEnumerable<TeamInGruppe> GruppeETeams { get; set; }
    public IEnumerable<GruppenSpielTurnierPlan> VergangeneGruppeESpiele { get; set; }
    public IEnumerable<GruppenSpielTurnierPlan> KommendeGruppeESpiele { get; set; }
    
    public IEnumerable<TeamInGruppe> GruppeFTeams { get; set; }
    public IEnumerable<GruppenSpielTurnierPlan> VergangeneGruppeFSpiele { get; set; }
    public IEnumerable<GruppenSpielTurnierPlan> KommendeGruppeFSpiele { get; set; }
    
    public IEnumerable<TeamInGruppe> GruppeGTeams { get; set; }
    public IEnumerable<GruppenSpielTurnierPlan> VergangeneGruppeGSpiele { get; set; }
    public IEnumerable<GruppenSpielTurnierPlan> KommendeGruppeGSpiele { get; set; }
}