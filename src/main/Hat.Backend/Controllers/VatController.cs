using Hat.Domain.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Hat.Backend.Controllers
{
    [ApiController]
    [Route("api/vats")]
    public class VatController : HatController
    {
        public VatController(IMediator mediator, ILogger<VatController> logger) : base(mediator, logger)
        {
        }
        [HttpGet("")]
        public async Task<IActionResult> GetVats()
        {
            _logger.LogInformation("GetVat");
            var vat = await _mediator.Send(new VatsQuery());
            return Ok(vat);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetVatById([FromQuery] Guid id)
        {
            _logger.LogInformation("GetVatById: {VatId}", id);
            var vat = await _mediator.Send(new VatByIdQuery(id));
            if (vat == null)
            {
                return NotFound();
            }
            return Ok(vat);
        }
    }
}
