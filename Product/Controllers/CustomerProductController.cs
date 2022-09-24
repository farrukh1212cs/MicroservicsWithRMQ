using MassTransit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Product.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerProductController : ControllerBase
    {
        private readonly IBus _busService;
        public CustomerProductController(IBus busService)
        {
            _busService = busService;
        }
        [HttpPost]
        public async Task<string> CreateProduct(Shared.Models.CustomerProduct product)
        {
            if (product != null)
            {
                product.AddedOnDate = DateTime.Now;
                Uri uri = new Uri("rabbitmq://localhost/productQueue");
                var endPoint = await _busService.GetSendEndpoint(uri);
                await endPoint.Send(product);
                return "true";
            }
            return "false";
        }


    }
}
