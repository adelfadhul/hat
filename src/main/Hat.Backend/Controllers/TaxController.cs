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
        public async Task<IActionResult> GetTaxes()
        {
            _logger.LogInformation("GetTaxes");
            var vat = await _mediator.Send(new TaxesQuery());
            return Ok(vat);
        }

        [HttpGet("user")]
        public async Task<IActionResult> GetUserTaxes()
        {
            _logger.LogInformation("GetTaxByUser");
            var userId = _userContext.GetUserId();
            var taxes = await _mediator.Send(new TaxesByUserQuery(userId));
            CheckUser(taxes.FirstOrDefault(), userId);
            return Ok(taxes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTaxById([FromQuery] Guid id)
        {
            _logger.LogInformation("GetTaxById: {TaxId}", id);
            var vat = await _mediator.Send(new TaxByIdQuery(id));
            
            return Ok(vat);
        }

        [HttpPost]
        public async Task<IActionResult> CreateVat([FromBody] CreateTaxCommand  command)
        {
            _logger.LogInformation("CreateTax: {command}", command.Name);
            var result = await _mediator.Send(command);

            // assuming result is the new product ID
            return CreatedAtAction(nameof(GetTaxById), new { id = result }, new { id = result });
        }
    }
}
