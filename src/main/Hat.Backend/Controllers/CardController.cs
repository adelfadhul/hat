using Hat.Domain.Commands;
using Hat.Domain.Identity;
using Hat.Domain.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Hat.Backend.Controllers
{

    [ApiController]
    [Route("api/cards")]
    public class CardController : HatController
    {
        public CardController(IMediator mediator, ILogger<CardController> logger,IUserContext userContext) : base(mediator, logger, userContext)
        {
        }

        [HttpGet("")]
        public async Task<IActionResult> GetCards()
        {
            _logger.LogInformation("GetCards");
            var list = await _mediator.Send(new CardsQuery());
            return Ok(list);
        }

        [HttpGet("user")]
        public async Task<IActionResult> GetCardsByUser()
        {
            _logger.LogInformation("GetCardsByUser");
            var userId = _userContext.GetUserId();

            var cards = await _mediator.Send(new CardsByUserQuery(userId));
            CheckUser(cards.FirstOrDefault(),userId);
            return Ok(cards);
        }

        [HttpGet("{CardId}")]
        public async Task<IActionResult> GetCard(Guid CardId)
        {
            _logger.LogInformation("GetCard: {CardId}", CardId);
            var card = await _mediator.Send(new CardByIdQuery(CardId));
            if (card == null)
            {
                return NotFound();
            }
            return Ok(card);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteCard(Guid id)
        {
            // Retrieve the card first
            var card = await _mediator.Send(new CardByIdQuery(id));
            if (card == null)
            {
                return NotFound();
            }

            // Check ownership
           

            _logger.LogInformation("DeleteCard: {id}", id);
            await _mediator.Send(new DeleteCardCommand(id));
            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCard([FromBody] CreateCardCommand command)
        {
            _logger.LogInformation("CreateCardInfo: {@command}", command);
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetCards), new { id }, null);
        }
    }
}
