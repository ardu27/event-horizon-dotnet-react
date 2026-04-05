using EventHorizon.API.Models;

namespace EventHorizon.API.Repositories;

public interface IEventRepository
{
    Task<IEnumerable<Event>> GetAllAsync();
    Task<Event?> GetByIdAsync(int id);
    Task<Event> AddAsync(Event @event);
    Task UpdateAsync(Event @event);
    Task DeleteAsync(Event @event);
}
