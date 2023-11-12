using MitternachtsCupMVC.Data.Enum;
using MitternachtsCupMVC.Models;

namespace MitternachtsCupMVC;

public class SpielViewModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Platten Platte { get; set; }
    public DateTime StartZeit { get; set; }
    public TimeSpan SpielDauer { get; set; }
    public int TeamAId { get; set; }
    public string TeamAName { get; set; }
    public int TeamBId { get; set; }
    public string TeamBName { get; set; }
}