using AstroCalculationsApi.Models.Stellar;
using AstroCalculationsApi.Enums;
using AstroCalculationsApi.Models;

namespace AstroCalculationsApi.Managers
{
    public class StellarManager
    {
        private const double Sigma = 5.670374419e-8; // Stefan–Boltzmann constant (W/m²·K⁴)

        public StellarRadiusResult CalculateRadius(double luminosity, double temperature)
        {
            if (luminosity <= 0 || temperature <= 0)
                throw new ArgumentException("Luminosity and temperature must be greater than zero.");

            double radiusSquared = luminosity / (4 * Math.PI * Sigma * Math.Pow(temperature, 4));

            var stellarRadiusResult = new StellarRadiusResult
            {
                Luminosity = new Quantity { Value = luminosity, Unit = PhysicalUnit.Watts },
                Temperature = new Quantity { Value = temperature, Unit = PhysicalUnit.Kelvin },
                Radius = new Quantity { Value = Math.Sqrt(radiusSquared), Unit = PhysicalUnit.Meters }
            };

            return stellarRadiusResult;
        }
    }
}
