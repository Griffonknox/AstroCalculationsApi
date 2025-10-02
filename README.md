# AstroCalculationsApi

A C# ASP.NET Core Web API for basic astronomy calculations.

## API Version

All endpoints are currently versioned as **v1**.

Base URL: `/api/v1/`

---

## Endpoints

### 1. Moon Phase

**GET** `/api/v1/SolarSystemAstronomy/moonphase?date=YYYY-MM-DD`

**Query Parameters:**
- `date` (required) – date to calculate the moon phase

**Example Request URL:** - https://localhost:5001/api/v1/localastronomy/moonphase?date=2025-09-26

**Example Response:**

```json
{
  "Date": "2025-09-26",
  "MoonPhase": "Waxing Crescent"
}
```

### 2. Stefan-Boltzmann Stellar Radius

**GET** /api/v1/stars/stephanboltzmann?luminosity={L}&temperature={T}

**Query Parameters and Units: **
- luminosity (required, >0) – Watts
- temperature (required, >0) – Kelvin

**Example Request URL:** - https://localhost:5001/api/v1/stars/stephanboltzmann?luminosity=3.828e26&temperature=5778

**Example Response:**

```json
{
  "Luminosity": 3.828e26,
  "Temperature": 5778,
  "RadiusMeters": 6.96e8
}


## Running Locally

**Clone the repository:**
- git clone <repo-url>
- cd AstroCalculationsApi

**Run the API:**
- dotnet run

**Swagger UI is available at:**
- https://localhost:{port}/swagger


## Logging

**HTTP requests and endpoint hits are automatically logged.**

**Logs appear in the Debug Output or console.**

**Each calculation also logs parameter values and results for traceability.**