using System.Text.Json;
using Basket.Domain.Entities;
using Basket.Domain.Repositories;
using Microsoft.Extensions.Caching.Distributed;

namespace Basket.Infrastructure.Repositories;

public sealed class BasketRepository(IDistributedCache distributedCache) : IBasketRepository
{
    private static readonly JsonSerializerOptions SerializerOptions = new(JsonSerializerDefaults.Web);

    public async Task<ShoppingCart?> GetBasket(string userName, CancellationToken cancellationToken = default)
    {
        var basketAsString = await distributedCache.GetStringAsync(userName, cancellationToken);

        return basketAsString is null
            ? null
            : JsonSerializer.Deserialize<ShoppingCart>(basketAsString, SerializerOptions);
    }

    public async Task<ShoppingCart> UpdateBasket(ShoppingCart shoppingCart, CancellationToken cancellationToken = default)
    {
        var serializedBasket = JsonSerializer.Serialize(shoppingCart, SerializerOptions);

        await distributedCache.SetStringAsync(shoppingCart.UserName, serializedBasket, cancellationToken);

        return shoppingCart;
    }

    public async Task DeleteBasket(string userName, CancellationToken cancellationToken = default)
    {
        await distributedCache.RemoveAsync(userName, cancellationToken);
    }
}
