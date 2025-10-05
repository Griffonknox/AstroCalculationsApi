# AstroCalculationsApi

A C# ASP.NET Core Web API for complex astronomy calculations.

## API Version

All endpoints are currently versioned as **v1**.

Base URL: `/api/v1/`

---

## Endpoints

### 1. Moon Phase

**POST** `/api/v1/SolarSystem/moonphase`

**Query Body:**
- `date` (required) – date to calculate the moon phase

**Example Request Body:**
```json
{
    "requestDate": "2025-10-04T14:09:32.618Z"
}
```

**Example Response:**
```json
{
  "requestDate": "10/4/2025",
  "moonPhase": "Full Moon"
}
```

### 2. Stellar Radius

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
  "luminosity": {
    "value": 1,
    "unit": "Watts"
  },
  "temperature": {
    "value": 4,
    "unit": "Kelvin"
  },
  "radius": {
    "value": 74.04047853822483,
    "unit": "Meters"
  }
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
	"lifetime": 
	{
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