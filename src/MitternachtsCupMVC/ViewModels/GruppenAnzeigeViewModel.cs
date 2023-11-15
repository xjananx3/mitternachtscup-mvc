using MitternachtsCupMVC.Data;
using MitternachtsCupMVC.Models;

namespace MitternachtsCupMVC;

public class GruppenAnzeigeViewModel
{
    public IEnumerable<TeamInGruppe> GruppeATeams { get; set; }
    public IEnumerable<GruppenSpielTurnierPlan>? GruppeASpiele { get; set; }
}