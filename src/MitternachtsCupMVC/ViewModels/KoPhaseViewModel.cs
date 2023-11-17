using MitternachtsCupMVC.Data;

namespace MitternachtsCupMVC;

public class KoPhaseViewModel
{
    public IEnumerable<KoSpiel> KommendeKoSpiele { get; set; }
    public IEnumerable<KoSpiel> VergangeneKoSpiele { get; set; }
}