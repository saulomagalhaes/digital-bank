using DigitalBank.Application.Contracts.Services;
using DigitalBank.Application.DTOs.Transaction;
using DigitalBank.Domain.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace DigitalBank.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TransactionController : BaseController
{
    private readonly ITransactionService _transactionService;
    private readonly ICurrentUser _currentUser;
    private readonly List<string> _permissionUser;
    private List<string> _permissionNeeded = new List<string>() { "Admin" };

    public TransactionController(ITransactionService transactionService, ICurrentUser currentUser)
    {
        _transactionService = transactionService;
        _currentUser = currentUser;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] CreateTransactionDto transactionDto)
    {
        _permissionNeeded.Add("User");
        var result = await _transactionService.CreateAsync(transactionDto);
        if (result.Success)
            return CreatedAtAction(nameof(GetByIdAsync), new { id = result.Data.Id }, result.Data);
        return BadRequest(new { result.Message, result.Errors });
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        _permissionNeeded.Add("User");
        var result = await _transactionService.DeleteAsync(id);
        if (result.Success)
            return NoContent();
        return NotFound(new { result.Message, result.Errors });
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        _permissionNeeded.Add("User");
        var result = await _transactionService.GetAllAsync();
        if (result.Success)
            return Ok(result.Data);
        return BadRequest();
    }

    [HttpGet("{id}")]
    [ActionName(nameof(GetByIdAsync))]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        _permissionNeeded.Add("User");
        var result = await _transactionService.GetByIdAsync(id);
        if (result.Success)
            return Ok(result.Data);
        return NotFound(new { result.Message, result.Errors });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(int id, [FromBody] UpdateTransactionDto transactionDto)
    {
        var result = await _transactionService.UpdateAsync(id, transactionDto);
        if (result.Success)
            return NoContent();
        if (result.Status == 400)
            return BadRequest(new { result.Message, result.Errors });
        return NotFound(new { result.Message, result.Errors });
    }
}
