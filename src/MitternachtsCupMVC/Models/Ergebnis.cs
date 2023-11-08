using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MitternachtsCupMVC.Models;

public class Ergebnis
{
    [Key]
    public int Id { get; set; }
    public int PunkteTeamA { get; set; }
    public int PunkteTeamB { get; set; }
    [ForeignKey("Spiel")]
    public int SpielId { get; set; }
    public Spiel Spiel { get; set; }
    [ForeignKey("Team")] 
    public int TeamId { get; set; }
    public Team GewinnerTeam { get; set; }
}