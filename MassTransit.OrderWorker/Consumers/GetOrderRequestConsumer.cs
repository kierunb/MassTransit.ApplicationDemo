using MassTransit.Contract;

namespace MassTransit.OrderWorker.Consumers;

public class GetOrderRequestConsumer : IConsumer<GetOrderRequest>
{
    private readonly ILogger<GetOrderRequestConsumer> _logger;

    public GetOrderRequestConsumer(ILogger<GetOrderRequestConsumer> logger)
    {
        _logger = logger;
    }


    // Pattern RPC = Request/Reply
    // Very similar to RequestHandler from MediatR library
    public async Task Consume(ConsumeContext<GetOrderRequest> context)
    {
        
        _logger.LogInformation(">>> Handling GetOrderRequest: {OrderId}", context.Message.OrderId);


        // var order = await _orderRepository.GetOrder(context.Message.OrderId);

        await context.RespondAsync(
            new GetOrderResponse { 
                OrderId = context.Message.OrderId, 
                OrderDescription = $"Order Description" }); 

    }
}
