using MassTransit;
using Shared.Models;

namespace Customer.Consumers
{
    public class ProductConsumer : IConsumer<CustomerProduct>
    {
        public async Task Consume(ConsumeContext<CustomerProduct> context)
        {

            await Task.Run(() => { var obj = context.Message; });
        }
    }
}
