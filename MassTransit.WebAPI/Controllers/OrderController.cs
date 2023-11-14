using MassTransit.Contract;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MassTransit.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        // scenario RPC, Request/Reply

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromServices]IRequestClient<GetOrderRequest> requestClient, int id)
        {
            
            var result = await requestClient.GetResponse<GetOrderResponse>(new { OrderId = id });
            
            
            return Ok(result);
        }

    }
}
