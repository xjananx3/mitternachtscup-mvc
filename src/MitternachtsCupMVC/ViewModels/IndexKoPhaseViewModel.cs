using MitternachtsCupMVC.Data;

namespace MitternachtsCupMVC;

public class IndexKoPhaseViewModel
{
    public IEnumerable<KoSpiel> KommendeAchtelfinals { get; set; }
    public IEnumerable<KoSpiel> VergangeneAchtelfinals { get; set; }
    public IEnumerable<KoSpiel> KommendeViertelfinals { get; set; }
    public IEnumerable<KoSpiel> VergangeneViertelfinals { get; set; }
    public IEnumerable<KoSpiel> KommendeHalbfinals { get; set; }
    public IEnumerable<KoSpiel> VergangeneHalbfinals { get; set; }
    public KoSpiel Finale { get; set; }
    public KoSpiel SpielUmPlatz3 { get; set; }
}