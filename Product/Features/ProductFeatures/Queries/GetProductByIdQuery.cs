using MediatR;
using Microsoft.EntityFrameworkCore;
using Product.Context;

namespace Product.Features.ProductFeatures.Queries
{
    public class GetProductByIdQuery : IRequest<Product.Models.Product>
    {
        public int Id { get; set; }
        public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Product.Models.Product>
        {
            private readonly IApplicationContext _context;
            public GetProductByIdQueryHandler(IApplicationContext context)
            {
                _context = context;
            }
            public async Task<Product.Models.Product> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
            {
                var product = await _context.Products.Where(a => a.Id == query.Id).FirstOrDefaultAsync();
                if (product == null) return null;
                return product;
            }
        }
    }
}
