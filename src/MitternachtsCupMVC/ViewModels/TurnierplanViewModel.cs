using MitternachtsCupMVC.Data;
using MitternachtsCupMVC.Models;

namespace MitternachtsCupMVC;

public class TurnierplanViewModel
{
    public ICollection<GruppenSpielTurnierPlan> GruppenSpiele { get; set; }
    
}