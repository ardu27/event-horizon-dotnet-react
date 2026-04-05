namespace EventHorizon.API.DTOs;

public class EventDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime Date { get; set; }
    public int CurrentAttendees { get; set; }
    public int OrganizerId { get; set; }
    public OrganizerDto? Organizer { get; set; }
}
