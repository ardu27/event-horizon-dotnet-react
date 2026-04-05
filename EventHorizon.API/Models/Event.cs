namespace EventHorizon.API.Models;

public class Event
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime Date { get; set; }
    public int CurrentAttendees { get; set; }
    
    public int OrganizerId { get; set; }
    public Organizer? Organizer { get; set; }
}
