using DigitalBank.Application.Contracts.Services;
using DigitalBank.Application.DTOs.Person;
using DigitalBank.Domain.FiltersDb;
using Microsoft.AspNetCore.Mvc;

namespace DigitalBank.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PersonController : ControllerBase
{
    private readonly IPersonService _personService;

    public PersonController(IPersonService personService)
    {
        _personService = personService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] CreatePersonDto personDto)
    {
        var result = await _personService.CreateAsync(personDto);
        if (result.Success)
            return CreatedAtAction(nameof(GetByIdAsync), new {id = result.Data.Id}, result.Data);
        return BadRequest(new {result.Message, result.Errors});
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _personService.DeleteAsync(id);
        if(result.Success)
            return NoContent();
        return NotFound(new {result.Message, result.Errors});
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var result = await _personService.GetAllAsync();
        if (result.Success)
            return Ok(result.Data);
        return BadRequest();
    }
    [HttpGet("{id}")]
    [ActionName(nameof(GetByIdAsync))]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        var result = await _personService.GetByIdAsync(id);
        if (result.Success)
            return Ok(result.Data);
        return NotFound(new { result.Message, result.Errors });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(int id, [FromBody] UpdatePersonDto personDto)
    {
        var result = await _personService.UpdateAsync(id, personDto);
        if(result.Success)
            return NoContent();
        if (result.Status == 400)
            return BadRequest(new { result.Message, result.Errors });
        return NotFound(new { result.Message, result.Errors });
    }

    [HttpGet("paged")]
    public async Task<IActionResult> GetPagedAsync([FromQuery] PersonFilterDb personFilterDb)
    {
        var result = await _personService.GetPagedAsync(personFilterDb);
        if(result.Success)
            return Ok(result.Data);
        return BadRequest();
    }
}
