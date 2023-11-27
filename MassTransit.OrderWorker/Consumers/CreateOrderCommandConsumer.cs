using MassTransit.Contract;

namespace MassTransit.OrderWorker.Consumers;

public class CreateOrderCommandConsumer : IConsumer<CreateOrderCommand>
{
    private readonly ILogger<CreateOrderCommandConsumer> _logger;

    public CreateOrderCommandConsumer(ILogger<CreateOrderCommandConsumer> logger)
    {
        _logger = logger;
    }


    public async Task Consume(ConsumeContext<CreateOrderCommand> context)
    {

        await Task.Delay(5000);
        
        _logger.LogInformation("OrderId: {orderId}, OrderName: {orderName}", 
            context.Message.OrderId, context.Message.OrderName);


        await context.Publish(
            new OrderCreatedEvent { OrderId = context.Message.OrderId, OrderStatus = "Completed" });

    }
}
