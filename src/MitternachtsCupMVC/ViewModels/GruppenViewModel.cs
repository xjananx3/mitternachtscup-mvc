using MitternachtsCupMVC.Models;

namespace MitternachtsCupMVC;

public class GruppenViewModel
{
    public IEnumerable<Team>? Teams { get; set; }
    public ICollection<GruppenSpiel> GruppenSpiele { get; set; }
}