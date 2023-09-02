using Api.Common;
using Api.Models.Auth;
using DotNetStarter.Commands.Auth.ForgotPassword;
using DotNetStarter.Commands.Auth.Login;
using DotNetStarter.Commands.Auth.ResetPassword;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiVersion(ApiVersions.Version1)]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<LoginResponse>> Login([FromBody] LoginRequest request)
        {
            var result = await _mediator.Send(new Login(request.Username!, request.Password!));

            return Ok(result);
        }

        [HttpPost]
        [Route("forgot-password")]
        public async Task<ActionResult> ForgotPassword([FromBody] ForgotPasswordRequest request)
        {
            await _mediator.Send(new ForgotPassword(request.Username!));

            return Ok();
        }

        [HttpPost]
        [Route("reset-password")]
        public async Task<ActionResult> ResetPassword([FromBody] ResetPasswordRequest request)
        {
            await _mediator.Send(new ResetPassword(request.Username!, request.Password!, request.Code!));

            return Ok();
        }
    }
}
