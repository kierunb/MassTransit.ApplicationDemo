using MassTransit.Contract;

namespace MassTransit.OrderWorker.Consumers;

public class PingCommandConsumer : IConsumer<PingCommand>
{
    private readonly ILogger<PingCommandConsumer> _logger;

    public PingCommandConsumer(
        ILogger<PingCommandConsumer> logger)
    {
        _logger = logger;
    }

    public Task Consume(ConsumeContext<PingCommand> context)
    {
        
        _logger.LogInformation(">>> Handling PingCommand: {PingCommandId} {Message}", 
            context.Message.PingCommandId, context.Message.Message);

        return Task.CompletedTask;
    }
}
