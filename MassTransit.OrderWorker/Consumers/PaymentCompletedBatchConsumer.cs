using MassTransit.Contract;

namespace MassTransit.OrderWorker;

public class PaymentCompletedBatchConsumer : IConsumer<Batch<PaymentCompletedEvent>>
{
    private readonly ILogger<PaymentCompletedBatchConsumer> _logger;

    public PaymentCompletedBatchConsumer(
        ILogger<PaymentCompletedBatchConsumer> logger)
    {
        _logger = logger;
    }
    
    public Task Consume(ConsumeContext<Batch<PaymentCompletedEvent>> context)
    {
        foreach (var paymentCompletedEvent in context.Message)
        {
            _logger.LogInformation(
                "Payment Completed: {paymentId}", paymentCompletedEvent.Message.PaymentId);
        }

        return Task.CompletedTask;
    }
}
