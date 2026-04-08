using Catalog.Application.Features.Products;
using Catalog.Domain.Repositories;
using MediatR;

namespace Catalog.Application.Features.Products.Queries.GetProducts;

public sealed class GetProductsQueryHandler(IProductRepository productRepository)
    : IRequestHandler<GetProductsQuery, IReadOnlyCollection<ProductDto>>
{
    public async Task<IReadOnlyCollection<ProductDto>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        var products = await productRepository.GetAll(cancellationToken);

        return products
            .Select(product => new ProductDto(
                product.Id,
                product.Name,
                product.Description,
                product.Price,
                product.Stock,
                product.CategoryId,
                product.ImageUrl,
                product.CreatedAt))
            .ToList();
    }
}
