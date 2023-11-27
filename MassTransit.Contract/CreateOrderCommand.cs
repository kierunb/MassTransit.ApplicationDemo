namespace MassTransit.Contract;

public record CreateOrderCommand
{
    public Guid OrderId { get; init; }
    public string OrderName { get; init; } = string.Empty;
    public string[] OrderItems { get; init; } = Array.Empty<string>();
}
