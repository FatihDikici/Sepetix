namespace Basket.Application.Features.Basket;

public sealed record BasketItemDto(
    string ProductId,
    string ProductName,
    decimal Price,
    int Quantity);
