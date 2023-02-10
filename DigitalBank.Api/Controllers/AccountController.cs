using DigitalBank.Application.Contracts.Services;
using DigitalBank.Application.DTOs.Account;
using DigitalBank.Domain.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace DigitalBank.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountController : BaseController
{
    private readonly IAccountService _accountService;
    private readonly ICurrentUser _currentUser;
    private readonly List<string> _permissionUser;
    private List<string> _permissionNeeded = new List<string>() { "Admin" };

    public AccountController(IAccountService accountService, ICurrentUser currentUser)
    {
        _accountService = accountService;
        _currentUser = currentUser;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] CreateAccountDto accountDto)
    {
        var result = await _accountService.CreateAsync(accountDto);
        if (result.Success)
            return CreatedAtAction(nameof(GetByIdAsync), new { id = result.Data.Id }, result.Data);
        return BadRequest(new { result.Message, result.Errors });
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync (int id)
    {
        var result =  await _accountService.DeleteAsync(id);
        if(result.Success)
            return NoContent();
        return NotFound(new { result.Message, result.Errors });
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var result = await _accountService.GetAllAsync();
        if(result.Success)
            return Ok(result);
        return BadRequest();
    }

    [HttpGet("{id}")]
    [ActionName(nameof(GetByIdAsync))]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        _permissionNeeded.Add("User");
        var result = await _accountService.GetByIdAsync(id);
        if(result.Success)
            return Ok(result);
        return NotFound(new { result.Message, result.Errors });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(int id, [FromBody] UpdateAccountDto accountDto)
    {
        var result = await _accountService.UpdateAsync(id, accountDto);
        if(result.Success)
            return NoContent();
        if(result.Status == 400)
            return BadRequest(new { result.Message, result.Errors });
        return NotFound(new { result.Message, result.Errors });
    }
}
