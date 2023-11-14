namespace MassTransit.Contract;

public record GetOrderResponse
{
    public int OrderId { get; init; }
    public string OrderNumber { get; init; } = string.Empty;
    public string OrderDescription { get; init; } = string.Empty;
    public DateTime OrderDate { get; init; }
    public decimal OrderAmount { get; init; }
}
