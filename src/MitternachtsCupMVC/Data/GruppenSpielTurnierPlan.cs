namespace MitternachtsCupMVC.Data;

public class GruppenSpielTurnierPlan
{
    public string Platte { get; set; }
    public int SpielId { get; set; }
    public string SpielName { get; set; }
    public string? StartZeit { get; set; }
    public int? TeamAId { get; set; }
    public string? TeamAName { get; set; }
    public int? TeamBId { get; set; }
    public string? TeamBName { get; set; }
    public string? Ergebnis { get; set; }
    public string? GewinnerName { get; set; }
}