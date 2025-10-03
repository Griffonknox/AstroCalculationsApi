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

**SUMMARY** - Calculates the radius of a star using the Stefan–Boltzmann law.

**POST** /api/v1/stellar/radius

**Query Body and Units: **
- luminosity (required, >0) – Watts
- temperature (required, >0) – Kelvin

**Example Request Body:**
```json
{
  "luminosity": 3.828e26,
  "temperature": 5778
}
```

**Example Response:**
```json
{
  "Luminosity": 3.828e26,
  "Temperature": 5778,
  "RadiusMeters": 6.96e8
}
```


### 3. Stellar Lifetime

**SUMMARY** - Estimates the main-sequence lifetime of a star based on its mass and optional luminosity.

**POST** /api/v1/stellar/lifetime

**Request Body and Units: **
- massSolar (required, >0) – Solar masses (M☉)
- luminositySolar (optional, >0) – Solar luminosities (L☉)

**Example Request Body:**
```json
{
  "massSolar": 2.0,
  "luminositySolar": null
}
```

**Example Response:**
```json
{
	"lifetime": {
		"value": 884194755,
		"unit": "Years"
	}
}
```

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