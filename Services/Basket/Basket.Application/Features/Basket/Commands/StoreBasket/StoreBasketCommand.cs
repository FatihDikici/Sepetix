using MediatR;

namespace Basket.Application.Features.Basket.Commands.StoreBasket;

public sealed record StoreBasketCommand(
    string UserName,
    IReadOnlyCollection<BasketItemDto> Items) : IRequest<BasketDto>;
