namespace AstroCalculationsApi.Models.Stellar
{
    public class StellarRadiusRequest
    {
        /// <summary>
        /// Luminosity of the star in watts (W)
        /// </summary>
        public double Luminosity { get; set; }

        /// <summary>
        /// Temperature of the star in Kelvin (K).
        /// </summary>
        public double Temperature { get; set; }
    }
}
