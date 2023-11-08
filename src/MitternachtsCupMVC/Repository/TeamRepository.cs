using Microsoft.EntityFrameworkCore;
using MitternachtsCupMVC.Data;
using MitternachtsCupMVC.Interfaces;
using MitternachtsCupMVC.Models;

namespace MitternachtsCupMVC.Repository;

public class TeamRepository : ITeamRepository
{
    private readonly ApplicationDbContext _context;

    public TeamRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<Team>> GetAll()
    {
        return await _context.Teams.ToListAsync();
    }

    public async Task<Team> GetByIdAsync(int id)
    {
        return await _context.Teams.FirstOrDefaultAsync(t => t.Id == id);
    }

    public bool Add(Team team)
    {
        _context.Add(team);
        return Save();
    }

    public bool Update(Team team)
    {
        _context.Update(team);
        return Save();
    }

    public bool Delete(Team team)
    {
        _context.Remove(team);
        return Save();
    }

    public bool Save()
    {
        var saved = _context.SaveChanges();
        return saved > 0 ? true : false;
    }
}