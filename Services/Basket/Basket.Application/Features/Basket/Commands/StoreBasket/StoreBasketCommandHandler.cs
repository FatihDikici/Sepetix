using Basket.Domain.Entities;
using Basket.Domain.Repositories;
using MediatR;

namespace Basket.Application.Features.Basket.Commands.StoreBasket;

public sealed class StoreBasketCommandHandler(IBasketRepository basketRepository) : IRequestHandler<StoreBasketCommand, BasketDto>
{
    public async Task<BasketDto> Handle(StoreBasketCommand request, CancellationToken cancellationToken)
    {
        var basket = new ShoppingCart
        {
            UserName = request.UserName,
            Items = request.Items
                .Select(item => new ShoppingCartItem
                {
                    ProductId = item.ProductId,
                    ProductName = item.ProductName,
                    Price = item.Price,
                    Quantity = item.Quantity
                })
                .ToList()
        };

        var storedBasket = await basketRepository.UpdateBasket(basket, cancellationToken);

        return new BasketDto(
            storedBasket.UserName,
            storedBasket.Items
                .Select(item => new BasketItemDto(
                    item.ProductId,
                    item.ProductName,
                    item.Price,
                    item.Quantity))
                .ToList());
    }
}
