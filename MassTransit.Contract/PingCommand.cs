namespace MassTransit.Contract;

// Command - is a message with intention to change state of the system

public record PingCommand
{
    public Guid PingCommandId { get; init; }
    public string Message { get; init; } = string.Empty;
}


// Event - is a message with intention to notify about state change of the system
public record PingConsumedEvent
{
    public Guid PingCommandId { get; init; }
    public string Message { get; init; } = string.Empty;
    public int ProcessingTime { get; init; }
}