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

        /// <summary>
        /// Calculates the radius of a star using the Stefan–Boltzmann law.
        /// </summary>
        /// <remarks>
        /// Example request:
        ///
        /// POST /api/v1/stellar/stefanboltzmann
        /// Content-Type: application/json
        ///
        /// {
        ///   "luminosity": 3.828e26,
        ///   "temperature": 5778
        /// }
        /// </remarks>
        /// <response code="200">Returns the calculated stellar radius</response>
        /// <response code="400">If the input is invalid</response>
        [HttpPost("stefanboltzmann")]
        public IActionResult CalculateRadius([FromBody] StefanBoltzmannRequest request)
        {
            _logger.LogInformation("Calculating radius with L={Luminosity}, T={Temperature}", request.Luminosity, request.Temperature);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var result = _stellarManager.CalculateRadius(request.Luminosity, request.Temperature);
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }

        [HttpPost("lifetime")]
        public IActionResult CalculateLifetime([FromBody] StellarLifetimeRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var result = _stellarManager.CalculateLifetime(request);
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

    }
}
