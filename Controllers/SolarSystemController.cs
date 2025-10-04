using Microsoft.AspNetCore.Mvc;
using AstroCalculationsApi.Models.SolarSystem;

namespace AstroCalculationsApi.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class SolarSystemController : ControllerBase
    {
        private readonly ILogger<SolarSystemController> _logger;

        public SolarSystemController(ILogger<SolarSystemController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Determines MoonPhase by given requested date.
        /// </summary>
        /// <remarks>
        /// Example request:
        ///
        /// POST /api/v1/solarsystem/moonphase
        /// Content-Type: application/json
        ///
        /// {
        ///   "requestDate": "2025-10-04T14:09:32.618Z"
        /// }
        ///
        /// Example response:
        /// {
        ///     "requestDate": "10/4/2025",
        ///     "moonPhase": "Full Moon"
        /// }
        /// </remarks>
        /// <response code="200">Returns the moonphase along with requested date</response>
        /// <response code="400">If the input is invalid (e.g., invalid date)</response>
        [HttpPost("moonphase")]
        public IActionResult GetMoonPhase([FromBody] MoonPhaseRequest moonPhaseRequest)
        {
            _logger.LogInformation("MoonPhase endpoint hit with date: {Date}", moonPhaseRequest.RequestDate.ToShortDateString());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            string phase = (moonPhaseRequest.RequestDate.Day % 8) switch
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
            var result = new MoonPhaseResult
            {
                RequestDate = moonPhaseRequest.RequestDate.ToShortDateString(),
                MoonPhase = phase
            };
            return Ok(result);
        }
    }
}
