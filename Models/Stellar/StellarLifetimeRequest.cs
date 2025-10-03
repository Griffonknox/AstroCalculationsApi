namespace AstroCalculationsApi.Models.Stellar
{
    public class StellarLifetimeRequest
    {
        /// <summary>
        /// Mass of the star in solar masses (M☉).
        /// </summary>
        public double MassSolar { get; set; }

        /// <summary>
        /// Luminosity of the star in solar luminosities (L☉). Optional. 
        /// If omitted, L ∝ M^3.5 will be used.
        /// </summary>
        public double? LuminositySolar { get; set; }
    }
}
