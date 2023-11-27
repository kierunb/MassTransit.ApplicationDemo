namespace MassTransit.Contract;

public record OrderCreatedEvent
{
    public Guid OrderId { get; init; }
    public string OrderStatus { get; init; } = string.Empty;
}
