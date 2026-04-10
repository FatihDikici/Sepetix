using Basket.Domain.Entities;

namespace Basket.Domain.Repositories;

public interface IBasketRepository
{
    Task<ShoppingCart?> GetBasket(string userName, CancellationToken cancellationToken = default);
    Task<ShoppingCart> UpdateBasket(ShoppingCart shoppingCart, CancellationToken cancellationToken = default);
    Task DeleteBasket(string userName, CancellationToken cancellationToken = default);
}
