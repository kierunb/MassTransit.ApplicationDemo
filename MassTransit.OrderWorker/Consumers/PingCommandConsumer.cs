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


public class PingBatchCommandConsumer : IConsumer<Batch<PingCommand>>
{
    private readonly ILogger<PingCommandConsumer> _logger;

    public PingBatchCommandConsumer(
        ILogger<PingCommandConsumer> logger)
    {
        _logger = logger;
    }

    public Task Consume(ConsumeContext<Batch<PingCommand>> context)
    {

        //_logger.LogInformation(">>> Handling PingCommand: {PingCommandId} {Message}",
        //    context.Message.PingCommandId, context.Message.Message);

        return Task.CompletedTask;
    }
}
