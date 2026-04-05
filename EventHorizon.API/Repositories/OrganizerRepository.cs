using EventHorizon.API.Data;
using EventHorizon.API.Models;
using Microsoft.EntityFrameworkCore;

namespace EventHorizon.API.Repositories;

public class OrganizerRepository : IOrganizerRepository
{
    private readonly ApplicationDbContext _context;

    public OrganizerRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Organizer>> GetAllAsync()
    {
        return await _context.Organizers.Include(o => o.Events).ToListAsync();
    }

    public async Task<Organizer?> GetByIdAsync(int id)
    {
        return await _context.Organizers.Include(o => o.Events).FirstOrDefaultAsync(o => o.Id == id);
    }

    public async Task<Organizer> AddAsync(Organizer organizer)
    {
        _context.Organizers.Add(organizer);
        await _context.SaveChangesAsync();
        return organizer;
    }

    public async Task UpdateAsync(Organizer organizer)
    {
        _context.Organizers.Update(organizer);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Organizer organizer)
    {
        _context.Organizers.Remove(organizer);
        await _context.SaveChangesAsync();
    }
}
