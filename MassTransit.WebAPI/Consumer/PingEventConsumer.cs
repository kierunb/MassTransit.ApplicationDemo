using MassTransit.Contract;

namespace MassTransit.WebAPI.Consumer;

public class PingEventConsumer : IConsumer<PingConsumedEvent>
{
    private readonly ILogger<PingEventConsumer> _logger;

    public PingEventConsumer(ILogger<PingEventConsumer> logger)
    {
        _logger = logger;
    }

    public Task Consume(ConsumeContext<PingConsumedEvent> context)
    {

        _logger.LogInformation("Handling PingConsumedEvent: {PingCommandId} {Message} {ProcessingTime}",
            context.Message.PingCommandId, context.Message.Message, context.Message.ProcessingTime);
        
        return Task.CompletedTask;
    }
}
