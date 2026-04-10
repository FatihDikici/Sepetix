using Basket.Domain.Repositories;
using MediatR;

namespace Basket.Application.Features.Basket.Queries.GetBasket;

public sealed class GetBasketQueryHandler(IBasketRepository basketRepository) : IRequestHandler<GetBasketQuery, BasketDto?>
{
    public async Task<BasketDto?> Handle(GetBasketQuery request, CancellationToken cancellationToken)
    {
        var basket = await basketRepository.GetBasket(request.UserName, cancellationToken);

        if (basket is null)
        {
            return null;
        }

        return new BasketDto(
            basket.UserName,
            basket.Items
                .Select(item => new BasketItemDto(
                    item.ProductId,
                    item.ProductName,
                    item.Price,
                    item.Quantity))
                .ToList());
    }
}
