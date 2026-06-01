using Microsoft.AspNetCore.Mvc;
using TraderDashboard.Application.Services;

namespace TraderDashboard.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UploadController : ControllerBase
{
    private readonly UploadService _uploadService;
    private const int DevUserId = 1;

    public UploadController(UploadService uploadService)
    {
        _uploadService = uploadService;
    }

    [HttpPost]
    [RequestSizeLimit(10 * 1024 * 1024)] // 10MB limit
    public async Task<IActionResult> Upload(IFormFile file)
    {
        if (file is null || file.Length == 0)
            return BadRequest("No file provided.");

        if (!file.FileName.EndsWith(".csv", StringComparison.OrdinalIgnoreCase))
            return BadRequest("Only CSV files are accepted.");

        using var stream = file.OpenReadStream();
        var result = await _uploadService.ProcessUploadAsync(stream, file.FileName, DevUserId);

        return Ok(result);
    }

    [HttpGet("logs")]
    public async Task<IActionResult> GetUploadLogs()
    {
        var logs = await _uploadService.GetUploadHistoryAsync(DevUserId);
        return Ok(logs);
    }
}