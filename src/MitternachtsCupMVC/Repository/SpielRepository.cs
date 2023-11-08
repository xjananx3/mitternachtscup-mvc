using Microsoft.EntityFrameworkCore;
using MitternachtsCupMVC.Data;
using MitternachtsCupMVC.Interfaces;
using MitternachtsCupMVC.Models;

namespace MitternachtsCupMVC.Repository;

public class SpielRepository : ISpielRepository
{
    private readonly ApplicationDbContext _context;

    public SpielRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<Spiel>> GetAll()
    {
        return await _context.Spiele.ToListAsync();
    }

    public async Task<Spiel> GetByIdAsync(int id)
    {
        return await _context.Spiele.FirstOrDefaultAsync(s => s.Id == id);
    }

    public bool Add(Spiel spiel)
    {
        _context.Add(spiel);
        return Save();
    }

    public bool Update(Spiel spiel)
    {
        _context.Update(spiel);
        return Save();
    }

    public bool Delete(Spiel spiel)
    {
        _context.Remove(spiel);
        return Save();
    }

    public bool Save()
    {
        var saved = _context.SaveChanges();
        return saved > 0 ? true : false;
    }
}