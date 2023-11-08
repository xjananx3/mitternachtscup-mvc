using MitternachtsCupMVC.Models;

namespace MitternachtsCupMVC.Interfaces;

public interface ISpielRepository
{
    Task<IEnumerable<Spiel>> GetAll();
    Task<Spiel> GetByIdAsync(int id);
    bool Add(Spiel spiel);
    bool Update(Spiel spiel);
    bool Delete(Spiel spiel);
    bool Save();
}