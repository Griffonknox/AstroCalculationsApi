using AstroCalculationsApi.Models.Stellar;
using AstroCalculationsApi.Enums;
using AstroCalculationsApi.Models;

namespace AstroCalculationsApi.Managers
{
    public class StellarManager
    {
        private const double Sigma = 5.670374419e-8; // Stefan–Boltzmann constant (W/m²·K⁴)
        private const double SolarLifetimeYears = 1e10; // 10 billion years

        public StellarRadiusResult CalculateRadius(double luminosity, double temperature)
        {
            if (luminosity <= 0 || temperature <= 0)
                throw new ArgumentException("Luminosity and temperature must be greater than zero.");

            double radiusSquared = luminosity / (4 * Math.PI * Sigma * Math.Pow(temperature, 4));

            return new StellarRadiusResult
            {
                Luminosity = new Quantity { Value = luminosity, Unit = PhysicalUnit.Watts },
                Temperature = new Quantity { Value = temperature, Unit = PhysicalUnit.Kelvin },
                Radius = new Quantity { Value = Math.Sqrt(radiusSquared), Unit = PhysicalUnit.Meters }
            };

        }

        public StellarLifetimeResult CalculateLifetime(StellarLifetimeRequest request)
        {
            if (request.MassSolar <= 0)
                throw new ArgumentException("Mass must be greater than zero.");

            double luminositySolar = request.LuminositySolar ?? Math.Pow(request.MassSolar, 3.5);

            if (luminositySolar <= 0)
                throw new ArgumentException("Luminosity must be greater than zero.");

            double lifetimeYears = SolarLifetimeYears * (request.MassSolar / luminositySolar);

            return new StellarLifetimeResult
            {
                Lifetime = new Quantity
                {
                    Value = lifetimeYears,
                    Unit = PhysicalUnit.Years
                }
            };
        }

        public StellarTemperatureResult CalculateTemperature(StellarTemperatureRequest request)
        {
            if (request.Luminosity <= 0)
                throw new ArgumentException("Luminosity must be greater than zero.");
            if (request.Radius <= 0)
                throw new ArgumentException("Radius must be greater than zero.");

            double temperature = Math.Pow(request.Luminosity / (4 * Math.PI * Sigma * Math.Pow(request.Radius, 2)), 0.25);

            return new StellarTemperatureResult
            {
                Luminosity = new Quantity { Value = request.Luminosity, Unit = PhysicalUnit.Watts },
                Radius = new Quantity { Value = request.Radius, Unit = PhysicalUnit.Meters },
                Temperature = new Quantity { Value = temperature, Unit = PhysicalUnit.Kelvin }
            };
        }
    }
}
