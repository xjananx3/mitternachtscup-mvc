using Microsoft.EntityFrameworkCore;
using MitternachtsCupMVC.Data;
using MitternachtsCupMVC.Interfaces;
using MitternachtsCupMVC.Models;

namespace MitternachtsCupMVC.Repository;

public class ErgebnisRepository : IErgebnisRepository
{
    private readonly ApplicationDbContext _context;

    public ErgebnisRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<Ergebnis>> GetAll()
    {
        return await _context.Ergebnisse.ToListAsync();
    }

    public async Task<Ergebnis> GetByIdAsync(int id)
    {
        return await _context.Ergebnisse.FirstOrDefaultAsync(e => e.Id == id);
    }

    public bool Add(Ergebnis ergebnis)
    {
        _context.Add(ergebnis);
        return Save();
    }

    public bool Update(Ergebnis ergebnis)
    {
        _context.Update(ergebnis);
        return Save();
    }

    public bool Delete(Ergebnis ergebnis)
    {
        _context.Remove(ergebnis);
        return Save();
    }

    public bool Save()
    {
        var saved = _context.SaveChanges();
        return saved > 0 ? true : false;
    }
}