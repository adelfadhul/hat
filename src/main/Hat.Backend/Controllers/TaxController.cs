using Hat.Domain.Commands;
using Hat.Domain.Identity;
using Hat.Domain.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Hat.Backend.Controllers
{
    [ApiController]
    [Route("api/taxes")]
    public class TaxController : HatController
    {
        public TaxController(IMediator mediator, ILogger<TaxController> logger, IUserContext userContext) : base(mediator, logger, userContext)
        {
        }
        [HttpGet("")]
        public async Task<IActionResult> GetVats()
        {
            _logger.LogInformation("GetVat");
            var vat = await _mediator.Send(new TaxesQuery());
            return Ok(vat);
        }

        [HttpGet("user")]
        public async Task<IActionResult> GetUserVats()
        {
            _logger.LogInformation("GetVatByUser");
            var userId = _userContext.GetUserId();
            var vat = await _mediator.Send(new TaxesByUserQuery(userId));
            CheckUser(vat.FirstOrDefault(), userId);
            return Ok(vat);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetVatById([FromQuery] Guid id)
        {
            _logger.LogInformation("GetVatById: {VatId}", id);
            var vat = await _mediator.Send(new TaxByIdQuery(id));
            
            return Ok(vat);
        }

        [HttpPost]
        public async Task<IActionResult> CreateVat([FromBody] CreateTaxCommand  command)
        {
            _logger.LogInformation("CreateVat: {command}", command.Name);
            var result = await _mediator.Send(command);

            // assuming result is the new product ID
            return CreatedAtAction(nameof(GetVatById), new { id = result }, new { id = result });
        }
    }
}
