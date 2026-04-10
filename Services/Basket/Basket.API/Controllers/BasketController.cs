using Basket.Application.Features.Basket.Commands.DeleteBasket;
using Basket.Application.Features.Basket.Commands.StoreBasket;
using Basket.Application.Features.Basket.Queries.GetBasket;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Basket.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class BasketController(IMediator mediator) : ControllerBase
{
    [HttpGet("{userName}")]
    public async Task<IActionResult> GetBasket(string userName, CancellationToken cancellationToken)
    {
        var basket = await mediator.Send(new GetBasketQuery(userName), cancellationToken);

        return basket is null ? NotFound() : Ok(basket);
    }

    [HttpPost]
    public async Task<IActionResult> StoreBasket([FromBody] StoreBasketCommand command, CancellationToken cancellationToken)
    {
        var basket = await mediator.Send(command, cancellationToken);
        return Ok(basket);
    }

    [HttpDelete("{userName}")]
    public async Task<IActionResult> DeleteBasket(string userName, CancellationToken cancellationToken)
    {
        await mediator.Send(new DeleteBasketCommand(userName), cancellationToken);
        return NoContent();
    }
}
