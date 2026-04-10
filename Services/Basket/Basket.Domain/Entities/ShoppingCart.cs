namespace Basket.Domain.Entities;

public sealed class ShoppingCart
{
    public string UserName { get; set; } = string.Empty;
    public List<ShoppingCartItem> Items { get; set; } = [];
}
