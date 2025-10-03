namespace AstroCalculationsApi.Models.Stellar
{
    public class StellarRadiusResult
    {
        public Quantity Luminosity { get; set; } = default!;
        public Quantity Temperature { get; set; } = default!;
        public Quantity Radius { get; set; } = default!;
    }
}
