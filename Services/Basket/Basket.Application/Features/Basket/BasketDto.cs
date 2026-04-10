namespace Basket.Application.Features.Basket;

public sealed record BasketDto(
    string UserName,
    IReadOnlyCollection<BasketItemDto> Items);
