using Microsoft.AspNetCore.Mvc;

namespace AstroCalculationsApi.Controllers
{

        [ApiController]
        [ApiVersion("1.0")] // ✅ mark this controller as v1
        [Route("api/v{version:apiVersion}/[controller]")]
        public class StellarController : ControllerBase
        {
            private readonly ILogger<StellarController> _logger;

            public StellarController(ILogger<StellarController> logger)
            {
                _logger = logger;
            }

            // GET /api/v1/stars/stephanboltzmann?luminosity=...&temperature=...
            [HttpGet("stephanboltzmann")]
            public IActionResult CalculateRadius([FromQuery] double luminosity, [FromQuery] double temperature)
            {
                // Validate input
                if (luminosity <= 0)
                    return BadRequest("Luminosity must be greater than 0.");
                if (temperature <= 0)
                    return BadRequest("Temperature must be greater than 0.");

                try
                {
                    const double sigma = 5.670374419e-8; // Stefan-Boltzmann constant
                    double radius = Math.Sqrt(luminosity / (4 * Math.PI * sigma * Math.Pow(temperature, 4)));

                    _logger.LogInformation(
                        "Stefan-Boltzmann calculation: Luminosity={Luminosity}, Temperature={Temperature}, Radius={Radius}",
                        luminosity, temperature, radius
                    );

                    return Ok(new
                    {
                        Luminosity = luminosity,
                        Temperature = temperature,
                        RadiusMeters = radius
                    });
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error calculating Stefan-Boltzmann radius.");
                    return StatusCode(500, "Internal server error while calculating radius.");
                }
            }
        }
}
