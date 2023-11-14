namespace MassTransit.Contract;

public record GetOrderRequest
{
    public int OrderId { get; init; }
}
