using MitternachtsCupMVC.Data;

namespace MitternachtsCupMVC.Interfaces;

public interface IKoPhaseRepository
{
    Task<IEnumerable<KoSpiel>> GetKommendeAchtelfinals();
    Task<IEnumerable<KoSpiel>> GetVergangeneAchtelfinals();
    Task<IEnumerable<KoSpiel>> GetKommendeViertelfinals();
    Task<IEnumerable<KoSpiel>> GetVergangeneViertelfinals();
    Task<IEnumerable<KoSpiel>> GetKommendeHalbfinals();
    Task<IEnumerable<KoSpiel>> GetVergangeneHalbfinals();
    Task<KoSpiel> GetFinale();
    Task<KoSpiel> GetSpielUmPlatz3();
}