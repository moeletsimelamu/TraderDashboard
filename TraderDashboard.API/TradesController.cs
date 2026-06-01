using Microsoft.AspNetCore.Mvc;
using TraderDashboard.Application.DTOs;
using TraderDashboard.Application.Services;

namespace TraderDashboard.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TradesController : ControllerBase
{
    private readonly TradeService _tradeService;

    // Temporary hardcoded userId until JWT is implemented
    private const int DevUserId = 1;

    public TradesController(TradeService tradeService)
    {
        _tradeService = tradeService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var trades = await _tradeService.GetTradesByUserAsync(DevUserId);
        return Ok(trades);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var trade = await _tradeService.GetTradeByIdAsync(id, DevUserId);
        return trade is null ? NotFound() : Ok(trade);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateTradeDto dto)
    {
        var created = await _tradeService.CreateTradeAsync(dto, DevUserId);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateTradeDto dto)
    {
        var success = await _tradeService.UpdateTradeAsync(id, DevUserId, dto);
        return success ? NoContent() : NotFound();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var success = await _tradeService.DeleteTradeAsync(id, DevUserId);
        return success ? NoContent() : NotFound();
    }
}