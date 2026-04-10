using Basket.Domain.Repositories;
using MediatR;

namespace Basket.Application.Features.Basket.Commands.DeleteBasket;

public sealed class DeleteBasketCommandHandler(IBasketRepository basketRepository) : IRequestHandler<DeleteBasketCommand>
{
    public async Task Handle(DeleteBasketCommand request, CancellationToken cancellationToken)
    {
        await basketRepository.DeleteBasket(request.UserName, cancellationToken);
    }
}
