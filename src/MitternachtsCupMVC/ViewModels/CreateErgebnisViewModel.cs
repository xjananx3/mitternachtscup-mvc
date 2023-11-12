using MitternachtsCupMVC.Models;

namespace MitternachtsCupMVC;

public class CreateErgebnisViewModel
{
    public int Id { get; set; }
    public int PunkteTeamA { get; set; }
    public int PunkteTeamB { get; set; }
    public int SpielId { get; set; }
    public Spiel Spiel { get; set; }
    public int TeamId { get; set; }
    public Team GewinnerTeam { get; set; }
}