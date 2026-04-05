using EventHorizon.API.Models;

namespace EventHorizon.API.Repositories;

public interface IOrganizerRepository
{
    Task<IEnumerable<Organizer>> GetAllAsync();
    Task<Organizer?> GetByIdAsync(int id);
    Task<Organizer> AddAsync(Organizer organizer);
    Task UpdateAsync(Organizer organizer);
    Task DeleteAsync(Organizer organizer);
}
