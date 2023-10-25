using Api.Common;
using Api.Models.Otps;
using DotNetStarter.Commands.Otps.ResendOtp;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiVersion(ApiVersions.Version1)]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class OtpsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OtpsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("resend")]
        public async Task<ActionResult> ResendOtp([FromForm] ResendOtpRequest request)
        {
            await _mediator.Send(new ResendOtp(request.Type!.Value, request.Code!));

            return Ok();
        }
    }
}
