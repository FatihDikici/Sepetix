using MediatR;

namespace Basket.Application.Features.Basket.Commands.DeleteBasket;

public sealed record DeleteBasketCommand(string UserName) : IRequest;
