using MassTransit.Contract;

namespace MassTransit.WebAPI.Consumer;

public class OrderCreatedEventConsumer : IConsumer<OrderCreatedEvent>
{
    private readonly ILogger<OrderCreatedEventConsumer> _logger;

    public OrderCreatedEventConsumer(ILogger<OrderCreatedEventConsumer> logger)
    {
        _logger = logger;
    }

    public Task Consume(ConsumeContext<OrderCreatedEvent> context)
    {
        _logger.LogInformation("Order Created: {orderId}", context.Message.OrderId);

        return Task.CompletedTask;
    }
}
