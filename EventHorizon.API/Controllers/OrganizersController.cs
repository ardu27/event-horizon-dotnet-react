using AutoMapper;
using EventHorizon.API.DTOs;
using EventHorizon.API.Models;
using EventHorizon.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EventHorizon.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrganizersController : ControllerBase
{
    private readonly IOrganizerRepository _repository;
    private readonly IMapper _mapper;

    public OrganizersController(IOrganizerRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<OrganizerDto>>> GetOrganizers()
    {
        var organizers = await _repository.GetAllAsync();
        return Ok(_mapper.Map<IEnumerable<OrganizerDto>>(organizers));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<OrganizerDto>> GetOrganizer(int id)
    {
        var organizer = await _repository.GetByIdAsync(id);

        if (organizer == null)
        {
            return NotFound();
        }

        return Ok(_mapper.Map<OrganizerDto>(organizer));
    }

    [HttpPost]
    public async Task<ActionResult<OrganizerDto>> PostOrganizer(OrganizerDto organizerDto)
    {
        var organizer = _mapper.Map<Organizer>(organizerDto);
        await _repository.AddAsync(organizer);

        var createdDto = _mapper.Map<OrganizerDto>(organizer);
        return CreatedAtAction(nameof(GetOrganizer), new { id = createdDto.Id }, createdDto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutOrganizer(int id, OrganizerDto organizerDto)
    {
        if (id != organizerDto.Id)
        {
            return BadRequest();
        }

        var organizer = await _repository.GetByIdAsync(id);
        if (organizer == null)
        {
            return NotFound();
        }

        _mapper.Map(organizerDto, organizer);
        await _repository.UpdateAsync(organizer);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteOrganizer(int id)
    {
        var organizer = await _repository.GetByIdAsync(id);
        if (organizer == null)
        {
            return NotFound();
        }

        await _repository.DeleteAsync(organizer);
        return NoContent();
    }
}
