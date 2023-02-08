namespace Api.Controllers
{
    using Domain.Dtos;
    using MediatR;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class InsuranceController : ControllerBase
    {
        private readonly IMediator _mediator;

        public InsuranceController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("RegisterInsurance")]
        public async Task<IActionResult> Post([FromBody] RegisterInsuranceCommand request)
        {
            var result = await _mediator.Send(request);

            return result.Error is null ? Ok(result) : StatusCode((int)result.Error, result);
        }

        [HttpGet()]
        [Route("GetInsurance")]
        public async Task<IActionResult> Get([FromQuery] GetInsuranceQuery request)
        {
            var result = await _mediator.Send(request);

            return result.Error is null ? Ok(result) : StatusCode((int)result.Error, result);
        }
    }
}
