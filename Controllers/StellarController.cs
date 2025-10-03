using Microsoft.AspNetCore.Mvc;
using AstroCalculationsApi.Managers;
using AstroCalculationsApi.Models.Stellar;

namespace AstroCalculationsApi.Controllers
{

    [ApiController]
    [ApiVersion("1.0")] 
    [Route("api/v{version:apiVersion}/[controller]")]
    public class StellarController : ControllerBase
    {
        private readonly ILogger<StellarController> _logger;
        private readonly StellarManager _stellarManager;

        public StellarController(ILogger<StellarController> logger, StellarManager stellarManager)
        {
            _logger = logger;
            _stellarManager = stellarManager;
        }

        // GET /api/v1/stars/stephanboltzmann?luminosity=...&temperature=...
        [HttpGet("stefanboltzmann")]
        public IActionResult CalculateRadius([FromQuery] double luminosity, [FromQuery] double temperature)
        {
            _logger.LogInformation("Calculating radius with L={Luminosity}, T={Temperature}", luminosity, temperature);

            try
            {
                var result = _stellarManager.CalculateRadius(luminosity, temperature);

                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }
    }
}
