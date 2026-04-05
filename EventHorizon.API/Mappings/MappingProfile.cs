using AutoMapper;
using EventHorizon.API.DTOs;
using EventHorizon.API.Models;

namespace EventHorizon.API.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Organizer, OrganizerDto>().ReverseMap();
        CreateMap<Event, EventDto>().ReverseMap();
    }
}
