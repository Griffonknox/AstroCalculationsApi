namespace AstroCalculationsApi.Models.Stellar
{
    public class StellarTemperatureRequest
    {
        /// <summary>
        /// Luminosity of the star in watts (W)
        /// </summary>
        public double Luminosity { get; set; }
        /// <summary>
        /// Radius of the star in Meters (M)
        /// </summary>
        public double Radius { get; set; }
    }
}
