using EventHorizon.API.Data;
using EventHorizon.API.Models;
using Microsoft.EntityFrameworkCore;

namespace EventHorizon.API.Repositories;

public class EventRepository : IEventRepository
{
    private readonly ApplicationDbContext _context;

    public EventRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Event>> GetAllAsync()
    {
        return await _context.Events.Include(e => e.Organizer).ToListAsync();
    }

    public async Task<Event?> GetByIdAsync(int id)
    {
        return await _context.Events.Include(e => e.Organizer).FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task<Event> AddAsync(Event @event)
    {
        _context.Events.Add(@event);
        await _context.SaveChangesAsync();
        return @event;
    }

    public async Task UpdateAsync(Event @event)
    {
        _context.Events.Update(@event);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Event @event)
    {
        _context.Events.Remove(@event);
        await _context.SaveChangesAsync();
    }
}
