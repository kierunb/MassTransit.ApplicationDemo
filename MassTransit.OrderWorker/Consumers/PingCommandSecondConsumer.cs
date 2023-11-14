

using MassTransit.Contract;

namespace MassTransit.OrderWorker.Consumers;


// Second Consumer = second class handling the same message type
// Consumer subcribes to specific message type
public class PingCommandSecondConsumer : IConsumer<PingCommand>
{
    private readonly ILogger<PingCommandSecondConsumer> _logger;

    public PingCommandSecondConsumer(
               ILogger<PingCommandSecondConsumer> logger)
    {
        _logger = logger;
    }

    public Task Consume(ConsumeContext<PingCommand> context)
    {
        _logger.LogInformation("%%% Handling PingCommand: {PingCommandId} {Message}",
                       context.Message.PingCommandId, context.Message.Message);

        return Task.CompletedTask;
    }
}

