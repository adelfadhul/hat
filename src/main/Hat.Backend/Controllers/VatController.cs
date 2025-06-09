using Hat.Domain.Commands;
using Hat.Domain.Identity;
using Hat.Domain.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Hat.Backend.Controllers
{
    [ApiController]
    [Route("api/vats")]
    public class VatController : HatController
    {
        public VatController(IMediator mediator, ILogger<VatController> logger, ILoginService loginService) : base(mediator, logger, loginService)
        {
        }
        [HttpGet("")]
        public async Task<IActionResult> GetVats()
        {
            _logger.LogInformation("GetVat");
            var vat = await _mediator.Send(new VatsQuery());
            ForbidIfUserIdMismatch(vat.FirstOrDefault());
            return Ok(vat);
        }

        [HttpGet("user")]
        public async Task<IActionResult> GetUserVats()
        {
            _logger.LogInformation("GetVatByUser");
            var vat = await _mediator.Send(new VatsByUserQuery(_currentUser.Oid()));
            ForbidIfUserIdMismatch(vat.FirstOrDefault());
            return Ok(vat);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetVatById([FromQuery] Guid id)
        {
            _logger.LogInformation("GetVatById: {VatId}", id);
            var vat = await _mediator.Send(new VatByIdQuery(id));
            ForbidIfUserIdMismatch(vat);
            return Ok(vat);
        }

        [HttpPost]
        public async Task<IActionResult> CreateVat([FromBody] CreateVatCommand  command)
        {
            _logger.LogInformation("CreateVat: {command}", command.Name);
            var result = await _mediator.Send(command);

            // assuming result is the new product ID
            return CreatedAtAction(nameof(GetVatById), new { id = result }, new { id = result });
        }
    }
}
