# Stock Enquiry Application
#ReadME Generated with the help of GITHUB_COPILOT
## 1. Overview

A stock enquiry application that allows users to search for an aircraft part number and view its available and reserved quantities across multiple inventory locations.

### Technology Stack
- Frontend: Angular, TypeScript, HTML, CSS
- Backend: ASP.NET Core Web API (.NET 8)
- Database: Microsoft SQL Server
- ORM: Entity Framework Core

## 2. Application Features

- Search stock by part number
- Display part description and stock by location
- Calculate total available and reserved quantities
- Validate mandatory part number input
- Trim whitespace and convert input to uppercase
- Display a loading indicator during API requests
- Handle API errors and unknown part numbers
- Display a message when a part has no stock
- Reset the search form and results

## 3. Architecture

Angular UI → ASP.NET Core Web API → Entity Framework Core → SQL Server

## 4. Database Setup

1. Open SQL Server Management Studio.
2. Execute `database/StockEnquiry.sql`.
3. Update the API connection string in `StockEnquiry.API/appsettings.json` to match your local SQL Server instance.

The script creates the `Parts` and `StockDetails` tables and inserts sample data.

## 5. Run the Backend

Open a terminal in `StockEnquiry.API` and run:

```bash
dotnet restore
dotnet build
dotnet run
```

Open the Swagger URL printed in the terminal to test the API.

## 6. Run the Frontend

Install Node.js and Angular CLI if they are not already installed.

Open a terminal in `stock-enquiry-ui` and run:

```bash
npm install
ng serve
```

Open `http://localhost:4200`.

Ensure the API is running and the API URL configured in the Angular component matches the backend URL.

## 7. API Documentation

### Endpoint

`GET /api/stock/{partNumber}`

Example request:

`GET /api/stock/PN-10001`

- `200 OK`: Part found; returns part details, totals and stock locations.
- `404 Not Found`: Part number does not exist.
- `400 Bad Request`: Invalid or empty part number.

### Sample Response

```json
{
  "partNumber": "PN-10001",
  "description": "Hydraulic Pump",
  "totalAvailable": 19,
  "totalReserved": 4,
  "stockDetails": [
    {
      "location": "LHR-WH",
      "locationType": "Warehouse",
      "availableQty": 12,
      "reservedQty": 3,
      "uom": "EA"
    }
  ]
}
```

The response above is abbreviated to show the structure; the actual response includes all stock locations.



## 8. Screenshots

See the `screenshots/` directory for the completed UI and API output.

## 9. Project Structure

- `StockEnquiry.API/`: Backend API source code
- `stock-enquiry-ui/`: Angular frontend source code
- `database/`: SQL Server creation and sample-data script
- `screenshots/`: Application output screenshots
