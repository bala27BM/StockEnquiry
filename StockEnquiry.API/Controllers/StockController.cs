
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StockEnquiry.API.Data;
using StockEnquiry.API.DTOs;

namespace StockEnquiry.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StockController : ControllerBase
{
    private readonly StockDbContext _context;

    public StockController(StockDbContext context)
    {
        _context = context;
    }

    [HttpGet("{partNumber}")]
    public async Task<IActionResult> GetStock(string partNumber)
    {
        // 1. Validate input
        if (string.IsNullOrWhiteSpace(partNumber))
        {
            return BadRequest(new
            {
                message = "Please enter a part number."
            });
        }

        // 2. Normalize input
        partNumber = partNumber.Trim().ToUpperInvariant();

        // 3. Fetch part and related stock details
        var part = await _context.Parts
            .Include(p => p.StockDetails)
            .FirstOrDefaultAsync(p => p.PartNumber == partNumber);

        // 4. Handle part not found
        if (part == null)
        {
            return NotFound(new
            {
                message = $"Part number {partNumber} was not found."
            });
        }

        // 5. Map entity to DTO
        var response = new StockResponseDto
        {
            PartNumber = part.PartNumber,
            Description = part.Description,

            TotalAvailable = part.StockDetails
                .Sum(s => s.AvailableQty),

            TotalReserved = part.StockDetails
                .Sum(s => s.ReservedQty),

            StockDetails = part.StockDetails.Select(s =>
                new StockItemDto
                {
                    Location = s.Location,
                    LocationType = s.LocationType,
                    AvailableQty = s.AvailableQty,
                    ReservedQty = s.ReservedQty,
                    UOM = part.UOM
                }).ToList()
        };

        // 6. Return successful response
        return Ok(response);
    }
}
