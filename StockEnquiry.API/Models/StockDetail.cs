
namespace StockEnquiry.API.Models;

public class StockDetail
{
    public int StockId { get; set; }

    public string PartNumber { get; set; } = string.Empty;

    public string Location { get; set; } = string.Empty;

    public string LocationType { get; set; } = string.Empty;

    public int AvailableQty { get; set; }

    public int ReservedQty { get; set; }

    public Part? Part { get; set; }
}
