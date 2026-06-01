using Microsoft.AspNetCore.Mvc;
using TraderDashboard.Application.Services;

namespace TraderDashboard.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AnalyticsController : ControllerBase
{
    private readonly AnalyticsService _analyticsService;
    private readonly BehaviourAnalyticsService _behaviourService;
    private const int DevUserId = 1;

    public AnalyticsController(
        AnalyticsService analyticsService,
        BehaviourAnalyticsService behaviourService)
    {
        _analyticsService = analyticsService;
        _behaviourService = behaviourService;
    }

    [HttpGet("summary")]
    public async Task<IActionResult> GetSummary() =>
        Ok(await _analyticsService.GetSummaryAsync(DevUserId));

    [HttpGet("equity-curve")]
    public async Task<IActionResult> GetEquityCurve() =>
        Ok(await _analyticsService.GetEquityCurveAsync(DevUserId));

    [HttpGet("by-strategy")]
    public async Task<IActionResult> GetByStrategy() =>
        Ok(await _analyticsService.GetStrategyPerformanceAsync(DevUserId));

    [HttpGet("by-day")]
    public async Task<IActionResult> GetByDay() =>
        Ok(await _analyticsService.GetPerformanceByDayAsync(DevUserId));

    [HttpGet("by-session")]
    public async Task<IActionResult> GetBySession() =>
        Ok(await _analyticsService.GetPerformanceBySessionAsync(DevUserId));

    [HttpGet("behaviour")]
    public async Task<IActionResult> GetBehaviour() =>
        Ok(await _behaviourService.GetBehaviourSummaryAsync(DevUserId));
}