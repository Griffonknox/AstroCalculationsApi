namespace AstroCalculationsApi.Models.Stellar
{
    public class StefanBoltzmannRequest
    {
        /// <summary>
        /// Luminosity of the star in watts (W) or solar luminosities depending on your API convention.
        /// </summary>
        public double Luminosity { get; set; }

        /// <summary>
        /// Temperature of the star in Kelvin (K).
        /// </summary>
        public double Temperature { get; set; }
    }
}
