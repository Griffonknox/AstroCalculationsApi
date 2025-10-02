using Microsoft.AspNetCore.Mvc;

namespace AstroCalculationsApi.Controllers
{
    [ApiController]
    [ApiVersion("1.0")] // ✅ mark this controller as v1
    [Route("api/v{version:apiVersion}/[controller]")]
    public class SolarSystemController : ControllerBase
    {
        private readonly ILogger<SolarSystemController> _logger;

        public SolarSystemController(ILogger<SolarSystemController> logger)
        {
            _logger = logger;
        }
        // Example: GET /api/v1/localastronomy/moonphase?date=2025-09-26
        [HttpGet("moonphase")]
        public IActionResult GetMoonPhase([FromQuery] DateTime date)
        {
            // Validate input
            if (date == default)
            {
                return BadRequest("Invalid date supplied.");
            }

            _logger.LogInformation("MoonPhase endpoint hit with date: {Date}", date);

            string phase = (date.Day % 8) switch
            {
                0 => "New Moon",
                1 => "Waxing Crescent",
                2 => "First Quarter",
                3 => "Waxing Gibbous",
                4 => "Full Moon",
                5 => "Waning Gibbous",
                6 => "Last Quarter",
                7 => "Waning Crescent",
                _ => "Unknown"
            };

            return Ok(new { Date = date.ToShortDateString(), MoonPhase = phase });
        }
    }
}
