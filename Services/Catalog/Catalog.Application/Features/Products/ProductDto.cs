namespace Catalog.Application.Features.Products;

public sealed record ProductDto(
    string Id,
    string Name,
    string Description,
    decimal Price,
    int Stock,
    string CategoryId,
    string ImageUrl,
    DateTime CreatedAt);
