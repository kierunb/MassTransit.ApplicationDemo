using MassTransit.Contract;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MassTransit.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;

        public OrderController(ILogger<OrderController> logger)
        {
            _logger = logger;
        }


        [HttpPost("create-order")]
        public async Task<IActionResult> CreateOrder([FromServices] IPublishEndpoint publishEndpoint, string orderName)
        {
            // asynchronous operation of sending/publishing message
            
            await publishEndpoint.Publish(new CreateOrderCommand
            {
                OrderId = NewId.NextGuid(),
                OrderName = orderName,
                OrderItems = new[] { "Marchewka", "Brukselka" }
            });
            
            return Accepted();
        }
        
        
        // scenario RPC, Request/Reply

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromServices]IRequestClient<GetOrderRequest> requestClient, int id)
        {
            
            var result = await requestClient.GetResponse<GetOrderResponse>(new { OrderId = id });
            
            
            return Ok(result);
        }


        // scenario batch publishing
        [HttpPost("batch-publish")]
        public async Task<IActionResult> BatchPublish([FromServices] IPublishEndpoint publishEndpoint)
        {
            var sw = new Stopwatch();

            var tasks = new List<Task>();
           
            for (int i = 0; i < 100; i++)
            {
                tasks.Add(publishEndpoint.Publish(new PaymentCompletedEvent
                {
                    PaymentId = NewId.NextGuid(),
                    Amount = 100,
                }));
            }

            await Task.WhenAll(tasks);

            sw.Stop();
            _logger.LogInformation(">>> Batch sent. Elapsed ms: {elapsed}",  sw.ElapsedMilliseconds);
            
            return Ok();
        }
    }
}
