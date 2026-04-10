using MediatR;

namespace Basket.Application.Features.Basket.Queries.GetBasket;

public sealed record GetBasketQuery(string UserName) : IRequest<BasketDto?>;
