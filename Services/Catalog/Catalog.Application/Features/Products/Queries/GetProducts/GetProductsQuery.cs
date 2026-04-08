using Catalog.Application.Features.Products;
using MediatR;

namespace Catalog.Application.Features.Products.Queries.GetProducts;

public sealed record GetProductsQuery : IRequest<IReadOnlyCollection<ProductDto>>;
