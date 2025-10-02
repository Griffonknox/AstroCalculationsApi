using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AstroCalculationsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AstronomyController : ControllerBase
    {

        // Example: GET api/astronomy/moonphase?date=2025-09-26
        [HttpGet("moonphase")]
        public IActionResult GetMoonPhase(DateTime date)
        {
            // Simple placeholder logic for now
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
