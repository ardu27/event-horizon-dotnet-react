using AutoMapper;
using EventHorizon.API.DTOs;
using EventHorizon.API.Models;
using EventHorizon.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EventHorizon.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EventsController : ControllerBase
{
    private readonly IEventRepository _repository;
    private readonly IMapper _mapper;

    public EventsController(IEventRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<EventDto>>> GetEvents()
    {
        var events = await _repository.GetAllAsync();
        return Ok(_mapper.Map<IEnumerable<EventDto>>(events));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<EventDto>> GetEvent(int id)
    {
        var @event = await _repository.GetByIdAsync(id);

        if (@event == null)
        {
            return NotFound();
        }

        return Ok(_mapper.Map<EventDto>(@event));
    }

    [HttpPost]
    public async Task<ActionResult<EventDto>> PostEvent(EventDto eventDto)
    {
        var @event = _mapper.Map<Event>(eventDto);
        await _repository.AddAsync(@event);

        // Fetch again to include the mapped Organizer if needed, but not strictly necessary here.
        var createdDto = _mapper.Map<EventDto>(@event);
        return CreatedAtAction(nameof(GetEvent), new { id = createdDto.Id }, createdDto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutEvent(int id, EventDto eventDto)
    {
        if (id != eventDto.Id)
        {
            return BadRequest();
        }

        var @event = await _repository.GetByIdAsync(id);
        if (@event == null)
        {
            return NotFound();
        }

        _mapper.Map(eventDto, @event);
        await _repository.UpdateAsync(@event);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEvent(int id)
    {
        var @event = await _repository.GetByIdAsync(id);
        if (@event == null)
        {
            return NotFound();
        }

        await _repository.DeleteAsync(@event);
        return NoContent();
    }
}
