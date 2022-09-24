using MediatR;
using Microsoft.EntityFrameworkCore;
using Product.Context;

namespace Product.Features.ProductFeatures.Queries
{
    public class GetAllProductsQuery : IRequest<IEnumerable<Product.Models.Product>>
    {
        public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<Product.Models.Product>>
        {
            private readonly IApplicationContext _context;
            public GetAllProductsQueryHandler(IApplicationContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<Product.Models.Product>> Handle(GetAllProductsQuery query, CancellationToken cancellationToken)
            {
                var productList = await _context.Products.ToListAsync();
                if (productList == null)
                {
                    return null;
                }
                return productList.AsReadOnly();
            }
        }
    }
}
