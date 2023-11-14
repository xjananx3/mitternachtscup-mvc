using MitternachtsCupMVC.Data;
using MitternachtsCupMVC.Models;

namespace MitternachtsCupMVC;

public class TurnierplanViewModel
{
    public ICollection<GruppenSpielTurnierPlan> GruppenSpieleMitErgebnis { get; set; }
    public ICollection<GruppenSpielTurnierPlan> GruppenSpieleOhneErgebnis { get; set; }
}