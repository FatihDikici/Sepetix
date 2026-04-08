using MediatR;

namespace Catalog.Application.Features.Products.Commands.CreateProduct;

public sealed record CreateProductCommand(
    string Name,
    string Description,
    decimal Price,
    int Stock,
    string CategoryId,
    string ImageUrl) : IRequest<string>;
