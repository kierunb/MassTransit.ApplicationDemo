namespace MassTransit.Contract;

public record PaymentCompletedEvent
{
    public Guid PaymentId { get; init; }
    public decimal Amount { get; init; }
    public DateTime Timestamp { get; init; }
}
