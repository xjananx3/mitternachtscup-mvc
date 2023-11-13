namespace MitternachtsCupMVC;

public class ErgebnisViewModel
{
    public int Id { get; set; }
    public string SpielName { get; set; }
    public int SpielId { get; set; }
    public string? TeamAName { get; set; }
    public int PunkteTeamA { get; set; }
    public string? TeamBName { get; set; }
    public int PunkteTeamB { get; set; }
    public int GewinnerTeamId { get; set; }
    public string? GewinnerTeamName { get; set; }
}