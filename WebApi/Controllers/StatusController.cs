using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class StatusController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<StatusController> _logger;

    public StatusController(ILogger<StatusController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public string Get()
    {
        _logger.LogInformation($"request");
        return Environment.MachineName;
    }
}
