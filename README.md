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

**Example Request URL:**

