using MitternachtsCupMVC.Models;

namespace MitternachtsCupMVC;

public class TurnierplanViewModel
{
    public IEnumerable<Spiel> Spiele { get; set; }
    public IEnumerable<Team> Teams { get; set; }
}