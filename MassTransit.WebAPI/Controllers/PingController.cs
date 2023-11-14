using MassTransit.Contract;
using Microsoft.AspNetCore.Mvc;

namespace MassTransit.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PingController : ControllerBase
    {

        // Scenarios for sending messages
        // 1) Publishing
        
        
        [HttpPost("")]
        public async Task<IActionResult> PublishPingCommand([FromServices] IPublishEndpoint publishEndpoint)
        {
            // read and validate request model

            // Patterns: Publish/Subscribe, Competing Consumers
            await publishEndpoint.Publish(new PingCommand
            {
                PingCommandId = NewId.NextGuid(), // instead of Guid.NewGuid(),
                Message = "Ping"
            });

            // return 202 - Accepted
            return Accepted();
        }

    }
}
