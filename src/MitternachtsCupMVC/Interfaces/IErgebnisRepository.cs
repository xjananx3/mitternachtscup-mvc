using MitternachtsCupMVC.Models;

namespace MitternachtsCupMVC.Interfaces;

public interface IErgebnisRepository
{
    Task<IEnumerable<Ergebnis>> GetAll();
    Task<Ergebnis> GetByIdAsync(int id);
    bool Add(Ergebnis ergebnis);
    bool Update(Ergebnis ergebnis);
    bool Delete(Ergebnis ergebnis);
    bool Save();
}