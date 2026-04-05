namespace EventHorizon.API.Models;

public class Organizer
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public List<Event> Events { get; set; } = new();
}