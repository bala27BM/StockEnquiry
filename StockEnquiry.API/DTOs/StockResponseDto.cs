
namespace StockEnquiry.API.DTOs;

public class StockResponseDto
{
    public string PartNumber { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public int TotalAvailable { get; set; }

    public int TotalReserved { get; set; }

    public List<StockItemDto> StockDetails { get; set; } = new();
}

public class StockItemDto
{
    public string Location { get; set; } = string.Empty;

    public string LocationType { get; set; } = string.Empty;

    public int AvailableQty { get; set; }

    public int ReservedQty { get; set; }

    public string UOM { get; set; } = string.Empty;
}
