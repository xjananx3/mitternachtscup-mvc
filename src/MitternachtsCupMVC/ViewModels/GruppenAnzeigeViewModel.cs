using MitternachtsCupMVC.Data;
using MitternachtsCupMVC.Models;

namespace MitternachtsCupMVC;

public class GruppenAnzeigeViewModel
{
    public IEnumerable<TeamInGruppe> GruppeATeams { get; set; }
    public IEnumerable<GruppenSpielTurnierPlan>? GruppeASpiele { get; set; }
    public IEnumerable<TeamInGruppe> GruppeBTeams { get; set; }
    public IEnumerable<TeamInGruppe> GruppeCTeams { get; set; }
    public IEnumerable<TeamInGruppe> GruppeDTeams { get; set; }
    public IEnumerable<TeamInGruppe> GruppeETeams { get; set; }
    public IEnumerable<TeamInGruppe> GruppeFTeams { get; set; }
    public IEnumerable<TeamInGruppe> GruppeGTeams { get; set; }
}